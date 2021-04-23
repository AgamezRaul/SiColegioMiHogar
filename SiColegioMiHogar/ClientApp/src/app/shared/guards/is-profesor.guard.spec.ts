import { TestBed } from '@angular/core/testing';

import { IsProfesorGuard } from './is-profesor.guard';

describe('IsProfesorGuard', () => {
  let guard: IsProfesorGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsProfesorGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
