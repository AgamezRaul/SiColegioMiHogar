import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormResponsablePadreComponent } from './form-responsable-padre.component';

describe('FormResponsablePadreComponent', () => {
  let component: FormResponsablePadreComponent;
  let fixture: ComponentFixture<FormResponsablePadreComponent>;

  beforeEach(async(() => {
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
