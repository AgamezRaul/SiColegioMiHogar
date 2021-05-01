import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormNotaPeriodoComponent } from './form-nota-periodo.component';

describe('FormNotaPeriodoComponent', () => {
  let component: FormNotaPeriodoComponent;
  let fixture: ComponentFixture<FormNotaPeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormNotaPeriodoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormNotaPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
