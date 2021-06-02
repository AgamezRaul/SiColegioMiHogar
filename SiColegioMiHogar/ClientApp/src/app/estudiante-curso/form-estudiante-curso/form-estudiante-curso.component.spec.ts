import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormEstudianteCursoComponent } from './form-estudiante-curso.component';

describe('FormEstudianteCursoComponent', () => {
  let component: FormEstudianteCursoComponent;
  let fixture: ComponentFixture<FormEstudianteCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormEstudianteCursoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormEstudianteCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
