import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { IPeriodo } from '../periodo.component';
import { PeriodoService } from '../periodo.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-form-periodo',
  templateUrl: './form-periodo.component.html',
  styleUrls: ['./form-periodo.component.css']
})
export class FormPeriodoComponent implements OnInit {

  constructor(private fb: FormBuilder, private periodoservice: PeriodoService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private alertService: AlertService) { }
  modoEdicion: boolean = false;
  id: number;
  idPerio: number;

  formGroup = this.fb.group({
    nombrePeriodo: ['', [Validators.required]],
    numeroPeriodo: ['', [Validators.required]],
    fechaInicio: ['', [Validators.required]],
    fechaFin:  ['', [Validators.required]],
  });
  
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      } else {
        this.modoEdicion = true;
      }
      this.id = params["id"];

      this.periodoservice.getPeriodo(this.id)
        .subscribe(periodo => this.cargarFormulario(periodo),
          error => this.alertService.error(error));
    });
  }

  cargarFormulario(periodo: IPeriodo) {
    console.table(periodo);
    this.formGroup.patchValue({
      nombrePeriodo: periodo.nombrePeriodo,
      numeroPeriodo: periodo.numeroPeriodo,
      fechaInicio: periodo.fechaInicio,
      fechaFin:  periodo.fechaFin,
    });
  }

  save(){
    let periodo: IPeriodo = Object.assign({}, this.formGroup.value);
    periodo.id = this.id;
    periodo.numeroPeriodo = parseInt(periodo.numeroPeriodo.toString());

    if (this.modoEdicion) {
      //editar registro
      this.periodoservice.updatePeriodo(periodo)
        .subscribe(response => this.onSaveSuccess()),
        error => console.error(error);
        console.table(periodo);
    } else {
      //agregar registro
      if (this.formGroup.valid) {
        this.periodoservice.createPeriodo(periodo)
        .subscribe(response => this.onSaveSuccess()),
        error => this.alertService.error(error);
      } else {
        this.alertService.info('No valido')
      }
    }
  }

  onSaveSuccess() {
    this.router.navigate(["periodos"]);
    this.alertService.success("Registro exitoso del periodo");
  }

  get numeroPeriodo() {
    return this.formGroup.get('numeroPeriodo');
  }

  get nombrePeriodo() {
    return this.formGroup.get('nombrePeriodo');
  }

  get fechaInicio() {
    return this.formGroup.get('fechaInicio');
  }

  get fechaFin() {
    return this.formGroup.get('fechaFin');
  }

}
