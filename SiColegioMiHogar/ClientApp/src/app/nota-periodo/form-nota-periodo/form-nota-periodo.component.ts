import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { MatTableDataSource } from '@angular/material/table';
import { UrlSegment } from '@angular/router';
import { IPeriodo } from '../../periodo/periodo.component';
import { PeriodoService } from '../../periodo/periodo.service';
import { MateriaService } from '../../materia/materia.service';
import { NotaPeriodoService } from '../nota-periodo.service';
import { IMateria } from '../../materia/materia.component';
import { INotaPeriodo } from '../nota-periodo.component';

@Component({
  selector: 'app-form-nota-periodo',
  templateUrl: './form-nota-periodo.component.html',
  styleUrls: ['./form-nota-periodo.component.css']
})
export class FormNotaPeriodoComponent implements OnInit {

  ListaPeriodos: IPeriodo[] = [];
  ListaMaterias: IMateria[] = [];
  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private periodoService: PeriodoService, private materiaService: MateriaService,
    private notaPeriodoService: NotaPeriodoService, private alertService: AlertService) { }
  modoEdicion: boolean = false;
  id: number;
  idNotaPeriodo: number;
  formGroup = this.fb.group({
    nota: [5, [Validators.required]],
    observacion: ['', [Validators.required]],
    idPeriodo: [1, [Validators.required]],
    idMateria: [1, [Validators.required]],
  });

  ngOnInit(): void {

    this.periodoService.getPeriodos()
      .subscribe(periodos => this.LlenarPeriodos(periodos),
      error => this.alertService.error(error.error));

    this.materiaService.getMaterias()
      .subscribe(materias => this.LlenarMaterias(materias),
      error => this.alertService.error(error.error));

    //con esto se el url utilizo el primer semento para saber que url esta activa

    // desde aca modifique y lo puse al final  
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;

      this.id = params["id"];

      this.notaPeriodoService.getNotaPeriodo(this.idNotaPeriodo)
        .subscribe(notaPeriodo => this.cargarFormulario(notaPeriodo),
          error => this.alertService.error(error.error));
    });
  }// desde atras modifique

  cargarFormulario(notaPeriodo: INotaPeriodo) {
    this.formGroup.patchValue({
      nota: notaPeriodo.nota,
      observacion: notaPeriodo.observacion,
      idPeriodo: notaPeriodo.idPeriodo,
      idMateria: notaPeriodo.idMateria
    });
  }

  LlenarPeriodos(periodos: IPeriodo[]) {
    this.ListaPeriodos = periodos;
  }

  LlenarMaterias(materias: IMateria[]) {
    this.ListaMaterias = materias;
  }

  save() {
    let notaPeriodo: INotaPeriodo = Object.assign({}, this.formGroup.value);
    console.table(notaPeriodo);
    notaPeriodo.idPeriodo = +notaPeriodo.idPeriodo;
    notaPeriodo.idMateria = +notaPeriodo.idMateria;
    console.table(notaPeriodo);

    if (this.modoEdicion) {
      //editar el regist
      notaPeriodo.id = this.idNotaPeriodo;
    //  if (this.formGroup.valid) {
        this.notaPeriodoService.updateNotaPeriodo(notaPeriodo)
          .subscribe(notaPeriodo => this.onSaveSuccess(),
            error => this.alertService.error(error));

        console.table(notaPeriodo);
   //   } else { console.log('No valido') }
    } else {

      console.table(notaPeriodo); //ver curso por consola
    //  if (this.formGroup.valid) {
        this.notaPeriodoService.createNotaPeriodo(notaPeriodo)
          .subscribe(notaPeriodo => this.onSaveSuccess(),
            error => this.alertService.error(error));
   //   } else {        console.log('No valido')      }
    }
  }

  onSaveSuccess() {
    this.router.navigate(["/lista-nota-periodo"]);
    this.alertService.success("Guardado Exitoso");
  }

  get nota() {
    return this.formGroup.get('nota');
  }
  get observacion() {
    return this.formGroup.get('observacion');
  }
  get idPeriodo() {
    return this.formGroup.get('idPeriodo');
  }
  get idMateria() {
    return this.formGroup.get('idMateria');
  }

}


/* const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());
    if (segments[0].toString() == 'registrar-notaPeriodo') {
      this.modoEdicion = false;
      console.log("Registrando Nota Periodo");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
      });
    } else {
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idNotaPeriodo"] == undefined) {
          return;
        }
        this.idNotaPeriodo = parseInt(params["idNotaPeriodo"]);
        this.notaPeriodoService.getNotaPeriodo(this.idNotaPeriodo)
          .subscribe(notaPeriodo => this.cargarFormulario(notaPeriodo),
            error => this.alertService.error(error.error));
        //validar cuando es repetida para avisarle al usuario
      });*/
