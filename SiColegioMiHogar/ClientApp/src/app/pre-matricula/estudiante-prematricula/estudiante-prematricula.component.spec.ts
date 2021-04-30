import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudiantePrematriculaComponent } from './estudiante-prematricula.component';

describe('EstudiantePrematriculaComponent', () => {
  let component: EstudiantePrematriculaComponent;
  let fixture: ComponentFixture<EstudiantePrematriculaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudiantePrematriculaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstudiantePrematriculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
