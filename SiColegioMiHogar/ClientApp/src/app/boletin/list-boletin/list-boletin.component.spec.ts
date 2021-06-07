import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBoletinComponent } from './list-boletin.component';

describe('ListBoletinComponent', () => {
  let component: ListBoletinComponent;
  let fixture: ComponentFixture<ListBoletinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListBoletinComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBoletinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
