import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPendingRequestComponent } from './my-pending-request.component';

describe('MyPendingRequestComponent', () => {
  let component: MyPendingRequestComponent;
  let fixture: ComponentFixture<MyPendingRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPendingRequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyPendingRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
