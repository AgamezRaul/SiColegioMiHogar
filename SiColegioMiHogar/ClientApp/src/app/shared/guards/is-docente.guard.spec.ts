import { TestBed } from '@angular/core/testing';

import { IsDocenteGuard } from './is-docente.guard';

describe('IsDocenteGuard', () => {
  let guard: IsDocenteGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsDocenteGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
