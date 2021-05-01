import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotaPeriodoComponent } from './nota-periodo.component';

describe('NotaPeriodoComponent', () => {
  let component: NotaPeriodoComponent;
  let fixture: ComponentFixture<NotaPeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotaPeriodoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotaPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
