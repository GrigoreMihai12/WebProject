import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CookieService } from 'ngx-cookie-service';
import { RequestService } from '../Services/request.service';
import { RecyclingRequest } from '../Models/RecyclingRequest'
import { User } from '../models/user';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.css']
})
export class AddRequestComponent implements OnInit {
  public addRequestForm: FormGroup;
  public centers: User[];
  constructor(
    private formBuilder: FormBuilder,
    private requestService: RequestService,
    private cookieService: CookieService,
    private modalService: NgbModal,
    private userService: UserService
  ) {
    this.addRequestForm = this.CreateEmptyForm();
  }
  private CreateEmptyForm(): FormGroup {
    return this.formBuilder.group({
      Date: ['', [Validators.required]],
      CenterID: ['', [Validators.required]],
      StatusID: ['Pending']
    });
  }
  get date() { return this.addRequestForm.get('Date'); }
  get centerID() { return this.addRequestForm.get('CenterID'); }
  get statusID() { return this.addRequestForm.get('StatusID'); }

  ngOnInit(): void {
    this.userService.GetUserByType("RECYCLING_CENTER").subscribe(resp => {
      this.centers = resp;
    })
  }

  createRequest() {
    if (this.addRequestForm.valid) {
      const requestFormValue = this.addRequestForm.value;
      var date = requestFormValue["Date"].year + "-" + requestFormValue["Date"].month + "-" + requestFormValue["Date"].day;
      var request = new RecyclingRequest(
        this.cookieService.get("Email"),
        +this.cookieService.get("ID"),
        +requestFormValue["CenterID"],
        date,
        requestFormValue["StatusID"]);
      this.requestService.AddRequest(request).subscribe(response => {
        window.location.reload();
        this.modalService.dismissAll();
      }, err => {
        alert(err.error)
      }
      )
    }
    else {
      Object.keys(this.addRequestForm.controls).forEach(field => {
        const control = this.addRequestForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }

  closeModal() {
    this.modalService.dismissAll();
  }
}
