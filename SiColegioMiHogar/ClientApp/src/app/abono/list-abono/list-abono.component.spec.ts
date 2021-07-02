import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAbonoComponent } from './list-abono.component';

describe('ListAbonoComponent', () => {
  let component: ListAbonoComponent;
  let fixture: ComponentFixture<ListAbonoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAbonoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAbonoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
