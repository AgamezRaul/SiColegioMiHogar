import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableActividadComponent } from './table-actividad.component';

describe('TableActividadComponent', () => {
  let component: TableActividadComponent;
  let fixture: ComponentFixture<TableActividadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableActividadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableActividadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
