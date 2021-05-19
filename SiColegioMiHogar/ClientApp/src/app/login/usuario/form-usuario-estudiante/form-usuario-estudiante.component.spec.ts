import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsuarioEstudianteComponent } from './form-usuario-estudiante.component';

describe('FormUsuarioEstudianteComponent', () => {
  let component: FormUsuarioEstudianteComponent;
  let fixture: ComponentFixture<FormUsuarioEstudianteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUsuarioEstudianteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsuarioEstudianteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
