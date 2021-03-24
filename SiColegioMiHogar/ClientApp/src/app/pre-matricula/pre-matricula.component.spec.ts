import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreMatriculaComponent } from './pre-matricula.component';

describe('PreMatriculaComponent', () => {
  let component: PreMatriculaComponent;
  let fixture: ComponentFixture<PreMatriculaComponent>;

  beforeEach(async(() => {
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
