import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FromMateriaComponent } from './from-materia.component';

describe('FromMateriaComponent', () => {
  let component: FromMateriaComponent;
  let fixture: ComponentFixture<FromMateriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FromMateriaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FromMateriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
