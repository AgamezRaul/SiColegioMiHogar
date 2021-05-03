import { TestBed } from '@angular/core/testing';

import { NotaPeriodoService } from './nota-periodo.service';

describe('NotaPeriodoService', () => {
  let service: NotaPeriodoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NotaPeriodoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
