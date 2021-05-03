import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableContratoComponent } from './table-contrato.component';

describe('TableContratoComponent', () => {
  let component: TableContratoComponent;
  let fixture: ComponentFixture<TableContratoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableContratoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableContratoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
