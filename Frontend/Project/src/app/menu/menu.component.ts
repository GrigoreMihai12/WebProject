import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { MaterialService } from '../Services/material.service';
import { UserService } from '../Services/user.service';

declare var navSlide;

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  isLogged: boolean = false;
  selectedNeighborhood: string;
  selectedMaterial: string;
  constructor(
    private userService: UserService,
    private materialService: MaterialService,
    private cookieService: CookieService,
    private router: Router,
    private _Activatedroute: ActivatedRoute
    ) { 
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
    return false;
  };}

  CallExternalJSFileFunction() {
    navSlide();
  }
  GoToLogin() {
    this.router.navigate(['/login'])
  }
  GoToProfile() {
    this.router.navigate(['/user-profile'])
  }
  GoToMaterial() {
    this.router.navigate(['/material'])
  }

  Logout() {
    this.cookieService.set("Email", "");
    this.cookieService.set("UserID", "");
    this.router.navigate(['/login']);
  }
  GoToSelectedMaterial(typeMaterial) {
    if (typeMaterial == "" || (typeMaterial != "plastic" && typeMaterial != "textiles" && typeMaterial != "paper" && typeMaterial != "metal")) {
      this.router.navigate(['/material']);
    }
    else {
      this.router.navigate(['/material/' + typeMaterial]);
    }
  }
  GoToSelectedNeighborhood(neighborhoodName) {
    this.router.navigate(['/neighborhood/' + neighborhoodName]);
  }
  ngOnInit(): void {
    var cookieEmail = this.cookieService.get("Email");
    this.isLogged = cookieEmail != "";

    this.selectedNeighborhood = this._Activatedroute.snapshot.paramMap.get("neighborhoodName");
    this.selectedMaterial = this._Activatedroute.snapshot.paramMap.get("typeMaterial");
  }

}
