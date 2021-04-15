import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePeriodoComponent } from './table-periodo.component';

describe('TablePeriodoComponent', () => {
  let component: TablePeriodoComponent;
  let fixture: ComponentFixture<TablePeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TablePeriodoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
