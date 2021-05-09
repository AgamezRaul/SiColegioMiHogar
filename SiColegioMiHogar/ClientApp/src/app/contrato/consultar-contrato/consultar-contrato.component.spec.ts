import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarContratoComponent } from './consultar-contrato.component';

describe('ConsultarContratoComponent', () => {
  let component: ConsultarContratoComponent;
  let fixture: ComponentFixture<ConsultarContratoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultarContratoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarContratoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
