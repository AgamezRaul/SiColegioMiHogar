import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListValorMensualidadComponent } from './list-valor-mensualidad.component';

describe('ListValorMensualidadComponent', () => {
  let component: ListValorMensualidadComponent;
  let fixture: ComponentFixture<ListValorMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListValorMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListValorMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
