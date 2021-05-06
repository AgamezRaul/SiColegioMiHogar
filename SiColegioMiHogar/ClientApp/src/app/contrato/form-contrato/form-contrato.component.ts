import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { AlertService } from '../../notifications/_services';
import { IContrato } from '../contrato.component';
import { ContratoService } from '../contrato.service';

@Component({
  selector: 'app-form-contrato',
  templateUrl: './form-contrato.component.html',
  styleUrls: ['./form-contrato.component.css']
})
export class FormContratoComponent implements OnInit {

  constructor(private fb: FormBuilder, private contratoService: ContratoService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location, private alertService: AlertService) { }
  modoEdicion: boolean = false;
  idDocente: number;
  formGroup = this.fb.group({
    fechaInicio: ['', [Validators.required]],
    fechaFin: ['', [Validators.required]],
    sueldo: ['', [Validators.required]]
  });
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["idDocente"] == undefined) {
        return;
      }
      this.modoEdicion = true;
      this.idDocente = params["idDocente"];
      this.contratoService.getContrato(this.idDocente)
        .subscribe(contrato => this.cargarFormulario(contrato)),
        error => this.alertService.error(error);
    });
  }
  cargarFormulario(contrato: IContrato) {
    this.formGroup.patchValue({
      fechaInicio: contrato.fechaInicio,
      fechaFin: contrato.fechaFin,
      sueldo: contrato.sueldo
    });
  }
   save() {
    let contrato: IContrato = Object.assign({}, this.formGroup.value);
 
     if (this.modoEdicion) {//editar el registro
       contrato.idDocente = this.idDocente;
       if (this.formGroup.valid) {
         this.contratoService.updateContrato(contrato)
          .subscribe(mensualidad => this.goBack(),
            error => this.alertService.error(error));
      } else { console.log('No valido') }
      
    }
  }
  goBack(): void {
    this.location.back();
  }
  get fechaInicio() {
    return this.formGroup.get('fechaInicio');
  }
  get fechaFin() {
    return this.formGroup.get('fechaFin');
  }
  get sueldo() {
    return this.formGroup.get('sueldo');
  }

}
