import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotasActividadComponent } from './notas-actividad.component';

describe('NotasActividadComponent', () => {
  let component: NotasActividadComponent;
  let fixture: ComponentFixture<NotasActividadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotasActividadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotasActividadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
