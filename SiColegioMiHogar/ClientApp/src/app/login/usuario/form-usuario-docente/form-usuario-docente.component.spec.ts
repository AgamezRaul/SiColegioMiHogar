import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsuarioDocenteComponent } from './form-usuario-docente.component';

describe('FormUsuarioDocenteComponent', () => {
  let component: FormUsuarioDocenteComponent;
  let fixture: ComponentFixture<FormUsuarioDocenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUsuarioDocenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsuarioDocenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
