import { Component, OnInit } from '@angular/core';
import { User } from '../Models/User';
import { Material } from '../Models/Material';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isLogged: boolean = false;
  isRecyclingUser: boolean = false;
  isRecyclingCenter: Boolean = false;
  isGuestUser:boolean=false;
  constructor(
    private cookieService: CookieService,
    private router: Router,
    private _Activatedroute: ActivatedRoute,
    private userService: UserService
  ) { }

  GoToCalendar() {
    this.router.navigate(['/calendar'])
  }
  GoToRequests(){
    this.router.navigate(['/requests'])
  }
  GoToAbout(){
    this.router.navigate(['/about'])
  }
  ngOnInit(): void {
    
    var cookieEmail = this.cookieService.get("Email");
    this.userService.GetUserByEmail(cookieEmail).subscribe(resp=>{
      if (resp.Type=="RECYCLING_USER") this.isRecyclingUser=true;
      if (resp.Type=="RECYCLING_CENTER") this.isRecyclingCenter=true;
    });
    this.isGuestUser = cookieEmail != "";
  }
}
