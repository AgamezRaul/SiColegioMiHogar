import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePrematriculaComponent } from './table-prematricula.component';

describe('TablePrematriculaComponent', () => {
  let component: TablePrematriculaComponent;
  let fixture: ComponentFixture<TablePrematriculaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TablePrematriculaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePrematriculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
