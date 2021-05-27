import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MateriaDocenteComponent } from './materia-docente.component';

describe('MateriaDocenteComponent', () => {
  let component: MateriaDocenteComponent;
  let fixture: ComponentFixture<MateriaDocenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MateriaDocenteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MateriaDocenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
