import { TestBed } from '@angular/core/testing';

import { GestionDeMateriasService } from './gestion-de-materias.service';

describe('GestionDeMateriasService', () => {
  let service: GestionDeMateriasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GestionDeMateriasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
