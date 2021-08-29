import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../Services/user.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service'
import { UserMaterialType } from '../models/UserMaterialType';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  constructor(
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder,
    private cookieService: CookieService
  ) {
    this.loginForm = this.CreateEmptyForm();
  }

  Login() {

    if (this.loginForm.valid) {
      let acceptedMaterialTypes: UserMaterialType[] = [];
      let user = new User(0, "", this.loginForm.value["Email"], "", "", this.loginForm.value["Password"], "RECYCLING_USER", "Gheorgheni", acceptedMaterialTypes);
      this.userService.Login(user).subscribe(result => {
        if (result) {
          this.userService.GetUserByEmail(user.Email).subscribe(resp => {
            this.cookieService.set("Email", resp.Email);
            this.cookieService.set("UserID", "" + resp.ID);
            this.router.navigate(['/home']);
          })
        }
        else {
          alert('Username or password error');
        }
      });
    }
    else {
      Object.keys(this.loginForm.controls).forEach(field => {
        const control = this.loginForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }
  private CreateEmptyForm(): FormGroup {
    return this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(3)]]
    });
  }

  get email() { return this.loginForm.get('Email'); }
  get password() { return this.loginForm.get('Password'); }
  

  Register() {
    this.router.navigate(['/register']);
  }
  ngOnInit(): void {
  }

}
