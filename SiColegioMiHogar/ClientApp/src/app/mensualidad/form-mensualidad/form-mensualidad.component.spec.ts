import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormMensualidadComponent } from './form-mensualidad.component';

describe('FormMensualidadComponent', () => {
  let component: FormMensualidadComponent;
  let fixture: ComponentFixture<FormMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
