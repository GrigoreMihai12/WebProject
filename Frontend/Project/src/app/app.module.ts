import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserService } from './Services/user.service'
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialService } from './Services/material.service';
import { RegisterComponent } from './register/register.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { NeighborhoodComponent } from './neighborhood/neighborhood.component';
import { MaterialComponent } from './material/material.component';
import { MenuComponent } from './menu/menu.component';
import { CalendarComponent } from './calendar/calendar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { HowToRecycleComponent } from './how-to-recycle/how-to-recycle.component';
import { AboutComponent } from './about/about.component';
import { MyPendingRequestComponent } from './my-pending-request/my-pending-request.component';
import { RequestService } from './Services/request.service';
import { AddRequestComponent } from './add-request/add-request.component';
import { AgmCoreModule } from '@agm/core';
import { TweetComponent } from './tweet/tweet.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    UserProfileComponent,
    NeighborhoodComponent,
    MaterialComponent,
    MenuComponent,
    AboutComponent,
    MyPendingRequestComponent,
    CalendarComponent,
    HowToRecycleComponent,
    AddRequestComponent,
    TweetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCI4RUVF_cUhf6UiKkh7DID9UC-vZlMVLg'
    })
  ],
  providers: [UserService, MaterialService, RequestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
