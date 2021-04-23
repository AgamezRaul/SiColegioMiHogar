import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { INota, INotaConsult,IEstudianteNota, IPeriodoNota, MateriaNota } from '../nota.component';
import { NotaService } from '../nota.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { EstudianteService } from '../../estudiante/estudiante.service';
import { PeriodoService } from '../../periodo/periodo.service';
import { IEstudiante } from '../../estudiante/estudiante.component';

@Component({
  selector: 'app-consultar-nota',
  templateUrl: './consultar-nota.component.html',
  styleUrls: ['./consultar-nota.component.css']
})
export class ConsultarNotaComponent implements OnInit {

  id: number;
  constructor(private fb: FormBuilder, private notaservice: NotaService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location,
    private estudianteService: EstudianteService, private periodoService: PeriodoService) { }

    formGroup = this.fb.group({
      Descripcion: ['', [Validators.required]],
      NotaAlumno: ['', [Validators.required]],
      IdEstudiante: ['', [Validators.required]],
      IdMateria:  ['', [Validators.required]],
      IdPeriodo:  ['', [Validators.required]],
      FechaNota: ['', [Validators.required]],
    });
    
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      params =>{
        if(params.has("id")){
          this.id = parseInt(params.get("id"));
          this.notaservice.getNota(this.id).subscribe(
            nota => {
              this.cargarFormulario(nota);
            },
          error => console.error(error));
        }
      }
    );
  }

  cargarFormulario(nota: INotaConsult) {
    console.log(nota);
    this.formGroup.patchValue({
      Descripcion:  nota.descripcion,
      NotaAlumno: nota.notaAlumno,
      IdEstudiante: nota.idEstudiante,
      IdMateria:  nota.idMateria,
      IdPeriodo:  nota.idPeriodo,
      FechaNota: nota.fechaNota,
    });
  }
}
