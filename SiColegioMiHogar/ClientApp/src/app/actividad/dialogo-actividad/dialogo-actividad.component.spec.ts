import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoActividadComponent } from './dialogo-actividad.component';

describe('DialogoActividadComponent', () => {
  let component: DialogoActividadComponent;
  let fixture: ComponentFixture<DialogoActividadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogoActividadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoActividadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
