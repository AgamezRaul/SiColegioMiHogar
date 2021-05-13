import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsuarioActualizarComponent } from './form-usuario-actualizar.component';

describe('FormUsuarioActualizarComponent', () => {
  let component: FormUsuarioActualizarComponent;
  let fixture: ComponentFixture<FormUsuarioActualizarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUsuarioActualizarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsuarioActualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
