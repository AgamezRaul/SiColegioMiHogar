import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValorMensualidadComponent } from './valor-mensualidad.component';

describe('ValorMensualidadComponent', () => {
  let component: ValorMensualidadComponent;
  let fixture: ComponentFixture<ValorMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValorMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValorMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
