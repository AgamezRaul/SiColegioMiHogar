import { TestBed } from '@angular/core/testing';

import { NotasActividadService } from './notas-actividad.service';

describe('NotasActividadService', () => {
  let service: NotasActividadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NotasActividadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
