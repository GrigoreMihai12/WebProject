import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HowToRecycleComponent } from './how-to-recycle.component';

describe('HowToRecycleComponent', () => {
  let component: HowToRecycleComponent;
  let fixture: ComponentFixture<HowToRecycleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HowToRecycleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HowToRecycleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
