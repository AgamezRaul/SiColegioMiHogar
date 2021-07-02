import { TestBed } from '@angular/core/testing';

import { ValorMensualidadService } from './valor-mensualidad.service';

describe('ValorMensualidadService', () => {
  let service: ValorMensualidadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ValorMensualidadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
