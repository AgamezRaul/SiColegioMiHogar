import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { FormResponsablePadreComponent } from './form-responsable-padre.component';

describe('FormResponsablePadreComponent', () => {
  let component: FormResponsablePadreComponent;
  let fixture: ComponentFixture<FormResponsablePadreComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FormResponsablePadreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormResponsablePadreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
