import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ResponsableComponent } from './responsable.component';

describe('ResponsableComponent', () => {
  let component: ResponsableComponent;
  let fixture: ComponentFixture<ResponsableComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ResponsableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponsableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
