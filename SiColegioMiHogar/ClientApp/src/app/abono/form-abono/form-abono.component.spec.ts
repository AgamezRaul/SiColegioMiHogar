import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAbonoComponent } from './form-abono.component';

describe('FormAbonoComponent', () => {
  let component: FormAbonoComponent;
  let fixture: ComponentFixture<FormAbonoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormAbonoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormAbonoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
