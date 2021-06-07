import { Component, OnInit } from '@angular/core';
import { error } from '@angular/compiler/src/util';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IEstudiante2 } from '../../estudiante/estudiante.component';
import { IPeriodo } from '../../periodo/periodo.component';
import { IBoletin } from '../boletin.component';
import { BoletinService } from '../boletin.service';
import { EstudianteService } from '../../estudiante/estudiante.service';
import { PeriodoService } from '../../periodo/periodo.service';
import { AlertService } from '../../notifications/_services';
import { Location } from '@angular/common';

@Component({
  selector: 'app-boletin-form',
  templateUrl: './boletin-form.component.html',
  styleUrls: ['./boletin-form.component.css']
})
export class BoletinFormComponent implements OnInit {
  ListaEstudiantes: IEstudiante2[] = [];
  ListaPeriodos: IPeriodo[] = [];

  constructor(private fb: FormBuilder, private periodoService: PeriodoService, private estudianteService: EstudianteService,
    private boletinService: BoletinService,private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private location: Location) { }

  formGroup = this.fb.group({
    idEstudiante: ['', [Validators.required]],
    idPeriodo: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.estudianteService.getEstudiantesUsuarios().subscribe(estudiantes => this.LLenarEstudiantes(estudiantes),
      error => this.alertService.error(error));
    this.periodoService.getPeriodos().subscribe(periodos => this.LLenarPeriodo(periodos),
      error => this.alertService.error(error));
  }
  save() {
    let boletin: IBoletin = Object.assign({}, this.formGroup.value);
    boletin.fechaGeneracion = new Date();
    boletin.idEstudiante = +boletin.idEstudiante;
    boletin.idPeriodo = +boletin.idPeriodo;
    //boletin.fechaGeneracion = new Date("2021-06-04T07:06:19.857");
    console.table(boletin); //ver usuario por consola
    if (this.formGroup.valid) {
      this.boletinService.createMensualidad(boletin)
      .subscribe(boletin => this.onSaveSuccess(),
      error => this.alertService.error(error));
    } else {
      console.log('No valido');
    }
  }
  onSaveSuccess() {
    this.location.back();
    this.alertService.success("Guardado exitoso");
  }
  LLenarEstudiantes(estudiantes: IEstudiante2[]) {
    this.ListaEstudiantes = estudiantes;
  }
  LLenarPeriodo(periodos: IPeriodo[]) {
    this.ListaPeriodos= periodos;
  }
  get idEstudiante() {
    return this.formGroup.get('idEstudiante');
  }
  get idPeriodo() {
    return this.formGroup.get('idPeriodo');
  }
 
}
