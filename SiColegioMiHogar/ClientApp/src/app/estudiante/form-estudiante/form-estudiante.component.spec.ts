import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormEstudianteComponent } from './form-estudiante.component';

describe('FormEstudianteComponent', () => {
  let component: FormEstudianteComponent;
  let fixture: ComponentFixture<FormEstudianteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormEstudianteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormEstudianteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
