import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormValorMensualidadComponent } from './form-valor-mensualidad.component';

describe('FormValorMensualidadComponent', () => {
  let component: FormValorMensualidadComponent;
  let fixture: ComponentFixture<FormValorMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormValorMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormValorMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
