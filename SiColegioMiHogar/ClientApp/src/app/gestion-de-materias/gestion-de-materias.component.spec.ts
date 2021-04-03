import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionDeMateriasComponent } from './gestion-de-materias.component';

describe('GestionDeMateriasComponent', () => {
  let component: GestionDeMateriasComponent;
  let fixture: ComponentFixture<GestionDeMateriasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GestionDeMateriasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionDeMateriasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
