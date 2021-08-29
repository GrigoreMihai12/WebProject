import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { RecyclingRequest } from '../Models/RecyclingRequest';
import { RequestService } from '../Services/request.service';

@Component({
  selector: 'app-my-pending-request',
  templateUrl: './my-pending-request.component.html',
  styleUrls: ['./my-pending-request.component.css']
})
export class MyPendingRequestComponent implements OnInit {
  requests: RecyclingRequest[] = [];
  constructor(
    private requestService: RequestService,
    private cookieService: CookieService
  ) { }

  ngOnInit(): void {
    var id = this.cookieService.get("UserID");
    this.requestService.GetPendingRequestByCenterID(+id).subscribe(response => {
      response.forEach(element => {
        var date = new Date(element.Date);
        var today = new Date();
        //if (today.getTime()<=date.getTime()){
          this.requests.push(element);
          //}
      });
    });
  }
  AcceptRequest(requestID) {
    this.requestService.AcceptRequest(requestID).subscribe(response => { window.location.reload() })
  }
  DeclinedRequest(requestID) {
    this.requestService.DeclinedRequest(requestID).subscribe(response => { window.location.reload() })
  }
}
