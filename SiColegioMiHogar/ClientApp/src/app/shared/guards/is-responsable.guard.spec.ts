import { TestBed } from '@angular/core/testing';

import { IsResponsableGuard } from './is-responsable.guard';

describe('IsResponsableGuard', () => {
  let guard: IsResponsableGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsResponsableGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
