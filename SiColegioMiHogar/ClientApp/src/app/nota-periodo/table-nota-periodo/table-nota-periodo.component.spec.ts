import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableNotaPeriodoComponent } from './table-nota-periodo.component';

describe('TableNotaPeriodoComponent', () => {
  let component: TableNotaPeriodoComponent;
  let fixture: ComponentFixture<TableNotaPeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableNotaPeriodoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableNotaPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
