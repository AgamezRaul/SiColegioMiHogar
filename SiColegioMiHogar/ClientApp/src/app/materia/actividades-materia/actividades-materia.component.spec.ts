import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActividadesMateriaComponent } from './actividades-materia.component';

describe('ActividadesMateriaComponent', () => {
  let component: ActividadesMateriaComponent;
  let fixture: ComponentFixture<ActividadesMateriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActividadesMateriaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActividadesMateriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
