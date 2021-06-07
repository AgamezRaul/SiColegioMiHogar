import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoletinFormComponent } from './boletin-form.component';

describe('BoletinFormComponent', () => {
  let component: BoletinFormComponent;
  let fixture: ComponentFixture<BoletinFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoletinFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoletinFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
