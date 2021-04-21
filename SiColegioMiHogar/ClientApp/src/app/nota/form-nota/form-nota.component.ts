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
import { IPeriodo } from '../../periodo/periodo.component';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-form-nota',
  templateUrl: './form-nota.component.html',
  styleUrls: ['./form-nota.component.css']
})
export class FormNotaComponent implements OnInit {

  ListaEstudiantes: IEstudianteNota[] = [];
  ListaPeriodos: IPeriodoNota[] = [];
  ListaMaterias: MateriaNota[] = [];

  constructor(private fb: FormBuilder, private notaservice: NotaService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location,
    private estudianteService: EstudianteService, private periodoService: PeriodoService,
    private alertService: AlertService  ) { }
  modoEdicion: boolean = false;
  id: number;
  idNota: number;

  formGroup = this.fb.group({
    Descripcion: ['', [Validators.required]],
    NotaAlumno: ['', [Validators.required]],
    IdEstudiante: ['', [Validators.required]],
    IdMateria:  ['', [Validators.required]],
    IdPeriodo:  ['', [Validators.required]],
  });

  ngOnInit(): void {
    this.estudianteService.getEstudiantes().subscribe(estudiantes => this.LLenarEstudiantes(estudiantes),
      error => this.alertService.error(error.error));
    this.periodoService.getPeriodos().subscribe(periodos => this.LLenarPeriodos(periodos),
      error => this.alertService.error(error.error));
    /*this.notaservice.getMaterias().subscribe(materias => this.LLenarMaterias(materias),
      error => console.error(error));*/
  }

  LLenarEstudiantes(estudantes: IEstudiante[]) {
    this.ListaEstudiantes = estudantes;
  }

  LLenarPeriodos(periodos: IPeriodo[]) {
    this.ListaPeriodos = periodos;
  }

  LLenarMaterias(materias: MateriaNota[]){
    this.ListaMaterias = materias;
  }

  cargarFormulario(nota: INotaConsult) {
    this.formGroup.patchValue({
      Descripcion:  nota.descripcion,
      NotaAlumno: nota.notaAlumno,
      IdEstudiante: nota.estudiante,
      IdMateria:  nota.materia,
      IdPeriodo:  nota.periodo,
    });
  }

  save(){
    let nota: INota = Object.assign({}, this.formGroup.value);
    if (this.formGroup.valid) {
      this.notaservice.createNota(nota)
        .subscribe(response => this.onSaveSuccess()),
        error => this.alertService.error(error.error);
    } else {
      this.alertService.info('No valido') 
    }
  }

  
  onSaveSuccess() {
    this.router.navigate(["listar-notas"]);
    this.alertService.success("Registrado exitoso");
  }

  get IdPeriodo() {
    return this.formGroup.get('IdPeriodo');
  }

  get IdMateria() {
    return this.formGroup.get('IdMateria');
  }

  get IdEstudiante() {
    return this.formGroup.get('IdEstudiante');
  }

  get NotaAlumno() {
    return this.formGroup.get('NotaAlumno');
  }

  get Descripcion() {
    return this.formGroup.get('Descripcion');
  }
}
