import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMensualidadComponent } from './edit-mensualidad.component';

describe('EditMensualidadComponent', () => {
  let component: EditMensualidadComponent;
  let fixture: ComponentFixture<EditMensualidadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMensualidadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMensualidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
