import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoseCustomerComponent } from './chose-customer.component';

describe('ChoseCustomerComponent', () => {
  let component: ChoseCustomerComponent;
  let fixture: ComponentFixture<ChoseCustomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChoseCustomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChoseCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
