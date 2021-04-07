import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMensualidadComponent } from './list-mensualidad.component';

describe('ListMensualidadComponent', () => {
  let component: ListMensualidadComponent;
  let fixture: ComponentFixture<ListMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
