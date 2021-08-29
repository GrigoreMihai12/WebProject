import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../Services/user.service';
import { CookieService } from 'ngx-cookie-service'
import { Profile } from '../Models/Profile';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../models/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  userProfile: Profile = new Profile("", "", "", "");
  currentUser: User;
  isEditting: boolean = false;
  public updateProfileForm: FormGroup;
  constructor(
    private userService: UserService,
    private router: Router,
    private cookieService: CookieService,
    private formBuilder: FormBuilder) {
    let email = cookieService.get("Email");
    this.userService.GetUserByEmail(email).subscribe(response => {
      this.userProfile = new Profile(
        response.Name,
        response.Email,
        response.PhoneNumber,
        response.Address);
      this.currentUser = new User(
        response.ID,
        response.Name,
        response.Email,
        response.PhoneNumber,
        response.Address,
        response.Password,
        response.Type,
        response.Neighbourhood,
        response.UserMaterialTypes
      )
    });
    this.updateProfileForm = this.createForm();
  }

  setEditProfile(){
    this.updateProfileForm.patchValue({
      Name: this.userProfile.Name,
      PhoneNumber: this.userProfile.PhoneNumber,
      Address: this.userProfile.Address
    });
    this.isEditting = true;
  }

  saveEdit(){
    if(this.updateProfileForm.valid){
        this.currentUser.Name = this.updateProfileForm.value["Name"];
        this.currentUser.PhoneNumber = this.updateProfileForm.value["PhoneNumber"];
        this.currentUser.Address = this.updateProfileForm.value["Address"];
        this.userService.UpdateUser(this.currentUser).subscribe(resp=>{
          this.reload();
        });  
        
    }
    this.isEditting = false;
  }

  cancelEdit(){
    console.log();
    this.isEditting = false;
  }
  goToHome() {
    this.router.navigate(['/home']);
  }

  reload(){
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/user-profile'])
  }

  private createForm(){
    return this.formBuilder.group({
        Name: ['',[Validators.required]],
        PhoneNumber: ['',[Validators.required]],
        Address: ['',[Validators.required]]
    })
  }
  ngOnInit(): void {

  }
}
