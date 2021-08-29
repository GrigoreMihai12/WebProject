import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { NeighborhoodComponent } from './neighborhood/neighborhood.component';
import { MaterialComponent } from './material/material.component';
import { CalendarComponent } from './calendar/calendar.component';
import { HowToRecycleComponent } from './how-to-recycle/how-to-recycle.component';
import {AboutComponent } from './about/about.component';
import { MyPendingRequestComponent } from './my-pending-request/my-pending-request.component';
import { TweetComponent } from './tweet/tweet.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'user-profile', component: UserProfileComponent },
  { path: 'neighborhood/:neighborhoodName', component:NeighborhoodComponent},
  { path: 'material', component: MaterialComponent },
  { path: 'material/:typeMaterial', component: MaterialComponent },
  { path: 'how-to-recycle', component: HowToRecycleComponent},
  { path: 'about', component: AboutComponent},
  {path:'calendar',component:CalendarComponent},
  { path:'requests', component:MyPendingRequestComponent},
  { path: 'tweet', component: TweetComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
