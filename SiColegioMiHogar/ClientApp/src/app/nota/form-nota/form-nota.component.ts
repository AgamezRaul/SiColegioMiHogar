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
import { MateriaService } from '../../materia/materia.service';
import { IMateria } from 'src/app/materia/materia.component';
import { AlertService } from '../../notifications/_services';


@Component({
  selector: 'app-form-nota',
  templateUrl: './form-nota.component.html',
  styleUrls: ['./form-nota.component.css']
})
export class FormNotaComponent implements OnInit {

  ListaEstudiantes: IEstudianteNota[] = [];
  ListaPeriodos: IPeriodoNota[] = [];
  ListaMaterias: IMateria[] = [];

  constructor(private fb: FormBuilder, private notaservice: NotaService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location,
    private estudianteService: EstudianteService, private periodoService: PeriodoService, private materiaService: MateriaService,private alertService: AlertService  ) { }

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
      error => this.alertService.error(error));
    this.periodoService.getPeriodos().subscribe(periodos => this.LLenarPeriodos(periodos),
      error => this.alertService.error(error));
    this.materiaService.getMaterias().subscribe(materia => this.LLenarMaterias(materia),
      error => this.alertService.error(error));

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      } else {
        this.modoEdicion = true;
      }
      this.id = params["id"];

      this.notaservice.getNota(this.id)
        .subscribe(nota => this.cargarFormulario(nota),
          error => this.alertService.error(error));
    });
  }

  LLenarEstudiantes(estudantes: IEstudiante[]) {
    this.ListaEstudiantes = estudantes;
  }

  LLenarPeriodos(periodos: IPeriodo[]) {
    this.ListaPeriodos = periodos;
  }

  LLenarMaterias(materias: IMateria[]){
    this.ListaMaterias = materias;
  }

  cargarFormulario(nota: INotaConsult) {
    console.table(nota);
    this.formGroup.patchValue({
      Descripcion:  nota.descripcion,
      NotaAlumno: nota.notaAlumno,
      IdEstudiante: nota.idEstudiante,
      IdMateria:  nota.idMateria,
      IdPeriodo:  nota.idPeriodo,
    });
  }

  save() {
    let nota: INota = Object.assign({}, this.formGroup.value);
    nota.IdMateria = parseInt(nota.IdMateria.toString());
    nota.IdEstudiante = parseInt(nota.IdEstudiante.toString());
    nota.IdPeriodo = parseInt(nota.IdPeriodo.toString());
    if (this.modoEdicion) {
      //editar registro
      nota.id = parseInt(this.id.toString());
      nota.IdMateria = parseInt(nota.IdMateria.toString());
      nota.IdEstudiante = parseInt(nota.IdEstudiante.toString());
      nota.IdPeriodo = parseInt(nota.IdPeriodo.toString());

      this.notaservice.updateNota(nota)
        .subscribe(response => this.onSaveSuccess()),

        error => console.error(error);
      console.table(nota);

    } else {
      //agregar registro
      if (this.formGroup.valid) {
        this.notaservice.createNota(nota)
          .subscribe(response => this.onSaveSuccess()),
          error => this.alertService.error(error);
      } else {
        this.alertService.info('No valido')
      }
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
