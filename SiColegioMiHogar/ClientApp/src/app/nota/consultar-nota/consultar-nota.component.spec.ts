import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarNotaComponent } from './consultar-nota.component';

describe('ConsultarNotaComponent', () => {
  let component: ConsultarNotaComponent;
  let fixture: ComponentFixture<ConsultarNotaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultarNotaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultarNotaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
