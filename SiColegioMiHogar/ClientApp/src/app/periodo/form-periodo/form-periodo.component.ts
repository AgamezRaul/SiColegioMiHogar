import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { IPeriodo } from '../periodo.component';
import { PeriodoService } from '../periodo.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';

@Component({
  selector: 'app-form-periodo',
  templateUrl: './form-periodo.component.html',
  styleUrls: ['./form-periodo.component.css']
})
export class FormPeriodoComponent implements OnInit {

  constructor(private fb: FormBuilder, private periodoservice: PeriodoService,private router: Router, private activatedRoute: ActivatedRoute, private location: Location) { }
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
    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-periodo') {
      this.modoEdicion = false;
      console.log("Registando");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
        console.log(this.id);

      });
    }else{
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idPeriodo"] == undefined) {
          return;
        }
        this.idPerio = parseInt(params["idPeriodo"]);
        console.log(this.idPerio);

        this.periodoservice.getPeriodo(this.idPerio)
          .subscribe(periodo => this.cargarFormulario(periodo),
            error => console.error(error));
        //validar cuando es repetida para avisarle al usuario
      });
    }
  }

  cargarFormulario(periodo: IPeriodo) {
    this.formGroup.patchValue({
      numeroPeriodo: periodo.numeroPeriodo,
      nombrePeriodo: periodo.nombrePeriodo,
      fechaInicio: periodo.fechaInicio,
      fechaFin: periodo.fechaFin
    });
  }

  save(){
    let periodo: IPeriodo = Object.assign({}, this.formGroup.value);
    if (this.formGroup.valid) {
      this.periodoservice.createPeriodo(periodo)
        .subscribe(response => this.onSaveSuccess()),
        error => console.error(error);
    }else{ 
      console.log('No valido') 
    }
  }

  onSaveSuccess() {
    this.router.navigate(["listar-periodos"]);
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
