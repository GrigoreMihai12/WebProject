import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { CalendarView, CalendarEvent, CalendarEventTimesChangedEvent } from 'angular-calendar';
import { Subject } from 'rxjs';
import {
  startOfDay,
  isSameDay,
  isSameMonth,
  addHours,
} from 'date-fns';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddRequestComponent } from '../add-request/add-request.component';
import { RecyclingRequest } from '../Models/RecyclingRequest';
import { RequestService } from '../Services/request.service';
import { CookieService } from 'ngx-cookie-service';
import { UserService } from '../Services/user.service';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  green: {
    primary: '#27964f',
    secondary: '#E8FDE7'
  }
};
@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  @ViewChild('modalContent', { static: true }) modalCFontent: TemplateRef<any>;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  item = {
    start: new Date(''),
    end: new Date(''),
    title: '',
    color: colors.red,
  };

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  refresh: Subject<any> = new Subject();

  events: CalendarEvent[] = [];

  activeDayIsOpen: boolean = true;

  recyclingRequests: RecyclingRequest[] = [];

  constructor(
    private modalService: NgbModal,
    private requestService: RequestService,
    private userService: UserService,
    private cookieService: CookieService
  ) { }

  ngOnInit(): void {
    this.loadCalendar();
  }
  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
  }
  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }
  openModal() {
    const modal = this.modalService.open(
      AddRequestComponent,
      { ariaLabelledBy: 'modal-basic-title', backdrop: 'static', keyboard: false });
    modal.result.then((reason) => {
      if (reason === 'save') {

      }
    });
  }
  private loadCalendar() {
    this.recyclingRequests = [];
    this.events = [];
    this.requestService.GetByUserID(+this.cookieService.get("UserID")).subscribe(resp => {
      this.recyclingRequests = resp;
      this.populateCalendarEvents(this.recyclingRequests);
    });
  }
  private populateCalendarEvents(recyclingRequests: RecyclingRequest[]) {
    this.events = [];
    if (recyclingRequests && recyclingRequests.length > 0) {
      recyclingRequests.forEach(request => {
          switch (request.Status) {
            case "Accepted":
              this.createItem(request, colors.green, "Accepted");
              break;
            case "Pending":
              this.createItem(request, colors.blue, "Pending");
              break;
            case "Declined":
              this.createItem(request, colors.red, "Declined");
              break;
          }
  
          if (this.events.indexOf(this.item) === -1) {
            this.events.push(this.item);
          }
      });
    }
  }

  private createItem(recyclingRequest: RecyclingRequest, color: string, status) {
    this.item = {
      start: new Date(recyclingRequest.Date),
      end: new Date(recyclingRequest.Date),
      title: recyclingRequest.CenterName + " - " + status,
      color: color,
    };
  }
}
