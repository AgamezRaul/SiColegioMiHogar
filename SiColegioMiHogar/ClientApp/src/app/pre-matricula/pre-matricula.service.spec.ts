import { TestBed } from '@angular/core/testing';

import { PreMatriculaService } from './pre-matricula.service';

describe('PreMatriculaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PreMatriculaService = TestBed.get(PreMatriculaService);
    expect(service).toBeTruthy();
  });
});
