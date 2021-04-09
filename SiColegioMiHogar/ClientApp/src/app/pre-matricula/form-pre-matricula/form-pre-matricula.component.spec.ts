import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormPreMatriculaComponent } from './form-pre-matricula.component';

describe('FormPreMatriculaComponent', () => {
  let component: FormPreMatriculaComponent;
  let fixture: ComponentFixture<FormPreMatriculaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormPreMatriculaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormPreMatriculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
