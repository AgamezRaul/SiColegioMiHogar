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
  }

  save(){
    let periodo: IPeriodo = Object.assign({}, this.formGroup.value);
    this.periodoservice.createPeriodo(periodo)
      .subscribe(response => this.onSaveSuccess()),
      error => this.alertService.error(error);

  }

  onSaveSuccess() {
    this.router.navigate(["periodos"]);
    this.alertService.success("Registro exitoso");
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
