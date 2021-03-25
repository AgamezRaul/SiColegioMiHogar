import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { FormResponsableAcudienteComponent } from './form-responsable-acudiente.component';

describe('FormResponsableAcudienteComponent', () => {
  let component: FormResponsableAcudienteComponent;
  let fixture: ComponentFixture<FormResponsableAcudienteComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FormResponsableAcudienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormResponsableAcudienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
