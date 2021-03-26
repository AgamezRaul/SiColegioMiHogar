import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { FormResponsableMadreComponent } from './form-responsable-madre.component';

describe('FormResponsableMadreComponent', () => {
  let component: FormResponsableMadreComponent;
  let fixture: ComponentFixture<FormResponsableMadreComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FormResponsableMadreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormResponsableMadreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
