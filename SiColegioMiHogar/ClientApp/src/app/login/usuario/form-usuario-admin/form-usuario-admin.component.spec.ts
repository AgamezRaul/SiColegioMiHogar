import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormUsuarioAdminComponent } from './form-usuario-admin.component';

describe('FormUsuarioAdminComponent', () => {
  let component: FormUsuarioAdminComponent;
  let fixture: ComponentFixture<FormUsuarioAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormUsuarioAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormUsuarioAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
