import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaceOrdrerComponent } from './place-ordrer.component';

describe('PlaceOrdrerComponent', () => {
  let component: PlaceOrdrerComponent;
  let fixture: ComponentFixture<PlaceOrdrerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaceOrdrerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaceOrdrerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
