import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../models/user';
import { UserService } from '../Services/user.service';
import { UserMaterialType } from '../models/UserMaterialType';
import { MaterialType } from '../models/MaterialType';
import { MaterialTypeService } from '../Services/materialType.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  isRecyclingCenter: boolean = false;
  userType: string = "RECYCLING_USER";
  materialTypeNames: string;
  public RegisterUserForm: FormGroup;
  id: string;
  materialTypes: MaterialType[] = [];
  registeredEmail: string;
  newUser: User;
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private materialTypeService: MaterialTypeService,
    private router: Router,
    private _Activatedroute: ActivatedRoute) {

    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    this.RegisterUserForm = this.CreateEmptyForm();
    this.materialTypeService.GetAllMaterialTypes().subscribe(
      result => this.materialTypes = result
    );
  }

  private CreateEmptyForm(): FormGroup {
    return this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.pattern("^[A-Za-z -]*$")]],
      Email: ['', [Validators.required, Validators.email]],
      PhoneNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^([ 0-9]){10,16}$")]],
      Address: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100), Validators.pattern("^[A-Za-z .,()0-9]*$")]],
      Password: ['', [Validators.required, Validators.minLength(3)]],
      ConfirmPassword: ["", [Validators.required, Validators.minLength(3)]],
      MaterialTypes: [""],
      SelectNeighbourhood: ["", [Validators.required]]
    });
  }

  MatchPasswords(password,confirmPassword) {
    if (this.RegisterUserForm!=undefined){
    let passwordControl = this.RegisterUserForm.controls[password];
    let confirmPasswordControl = this.RegisterUserForm.controls[confirmPassword];

    if (passwordControl.value !== confirmPasswordControl.value) {
      confirmPasswordControl.setErrors({ matchPasswords: true });
    } else {
      confirmPasswordControl.setErrors(null);
    }
  }
  }

  get name() { return this.RegisterUserForm.get('Name'); }
  get email() { return this.RegisterUserForm.get('Email'); }
  get phoneNumber() { return this.RegisterUserForm.get('PhoneNumber'); }
  get address() { return this.RegisterUserForm.get('Address'); }
  get password() { return this.RegisterUserForm.get('Password'); }
  get confirmPassword() { return this.RegisterUserForm.get('ConfirmPassword'); }
  get getMaterialTypes() { return this.RegisterUserForm.get('MaterialTypes'); }
  get selectNeighbourhood() { return this.RegisterUserForm.get('SelectNeighbourhood'); }

  submit() {
    const userFormValue = this.RegisterUserForm.value;
    let acceptedMaterialTypes = this.materialTypes.filter(x => x.Checked === true);
    this.registeredEmail = userFormValue["Email"];
    var user = new User(
      +this.id,
      userFormValue["Name"],
      userFormValue["Email"],
      userFormValue["PhoneNumber"],
      userFormValue["Address"],
      userFormValue["Password"],
      this.userType,
      userFormValue["SelectNeighbourhood"],
      []
    )
      this.MatchPasswords("Password","ConfirmPassword");
      if (this.RegisterUserForm.valid) {
      this.userService.AddUser(user).subscribe(resp => {
        alert('S-a inregistrat cu succes');
        this.setAcceptedMaterialTypes(acceptedMaterialTypes);
        this.router.navigate(['/login']);
      }, err => {
        alert(err.error);
      });
    } else {
      Object.keys(this.RegisterUserForm.controls).forEach(field => {
        const control = this.RegisterUserForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
      document.getElementById("registerPageBackground").style.height = "100%";
    }
  }

  GoToLogin() {
    this.router.navigate(['/login']);
  }

  ngOnInit(): void {
  }

  GoToRegisterCenter() {
    this.isRecyclingCenter = true;
    this.userType = "RECYCLING_CENTER";
  }

  GoToRegisterUser() {
    this.isRecyclingCenter = false;
    this.userType = "RECYCLING_USER";
  }

  onCheckBoxChange(event) {
    if (event.target.checked) {
      this.GoToRegisterCenter();
      document.getElementById("registerPageBackground").style.height = "100%";
    }
    else {
      this.GoToRegisterUser();
      document.getElementById("registerPageBackground").style.height = "100vh";
    }
  }

  async setAcceptedMaterialTypes(acceptedMaterialTypes) {
    let userMaterialTypes: UserMaterialType[] = new Array();
    this.getRegisteredUser().then(() => {

      acceptedMaterialTypes.forEach(materialType => {
        userMaterialTypes.push(
          new UserMaterialType(this.newUser.ID, materialType.ID)
        );
      });
      this.newUser.UserMaterialTypes = userMaterialTypes;
      this.userService.UpdateUser(this.newUser).subscribe(
        response => console.log(response),
        error => console.log(error)
      );
    });
  }

  getRegisteredUser() {
    return new Promise<void>((resolve) => {
      this.userService.GetUserByEmail(this.registeredEmail).subscribe(response => {
        this.newUser = new User(
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
        resolve();
      });
    });
  }
}
