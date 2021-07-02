import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoPreMatriculaComponent } from './dialogo-pre-matricula.component';

describe('DialogoPreMatriculaComponent', () => {
  let component: DialogoPreMatriculaComponent;
  let fixture: ComponentFixture<DialogoPreMatriculaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogoPreMatriculaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoPreMatriculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
