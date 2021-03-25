import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PreMatriculaComponent } from './pre-matricula.component';

describe('PreMatriculaComponent', () => {
  let component: PreMatriculaComponent;
  let fixture: ComponentFixture<PreMatriculaComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PreMatriculaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreMatriculaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
