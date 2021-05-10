import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { AlertService } from '../../notifications/_services';
import { IContrato } from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { DocenteService } from '../../docente/docente.service';
import { IDocente } from '../../docente/docente.component';

@Component({
  selector: 'app-form-contrato',
  templateUrl: './form-contrato.component.html',
  styleUrls: ['./form-contrato.component.css']
})
export class FormContratoComponent implements OnInit {

  listaDocentes: IDocente[];

  constructor(private fb: FormBuilder, private contratoService: ContratoService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location,
    private alertService: AlertService, private docenteService: DocenteService) { }
  modoEdicion: boolean = false;
  idDocente: number;
  formGroup = this.fb.group({
    fechaInicio: ['', [Validators.required]],
    fechaFin: ['', [Validators.required]],
    sueldo: ['', [Validators.required]],
    idDocente: ['', [Validators.required]]
  });
  ngOnInit(): void {
    this.docenteService.getDocentesEstado()
      .subscribe(docentes => this.llenarDocentes(docentes),
        error => this.alertService.error(error));

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
  llenarDocentes(docentes: IDocente[]) {
    this.listaDocentes = docentes;
  }
  cargarFormulario(contrato: IContrato) {
    this.formGroup.patchValue({
      fechaInicio: contrato.fechaInicio,
      fechaFin: contrato.fechaFin,
      sueldo: contrato.sueldo,
      idDocente:this.idDocente
    });
  }
   save() {
     let contrato: IContrato = Object.assign({}, this.formGroup.value);
     contrato.idDocente = parseInt(contrato.idDocente.toString());
     console.log(contrato.idDocente);
     if (this.modoEdicion) {//editar el registro
      if (this.formGroup.valid) {
        this.contratoService.updateContrato(contrato)
        .subscribe(contrato => this.goBack(),
          error => this.alertService.error(error.error));
      }
     } else {//crea
       console.log(contrato);
       this.contratoService.createContrato(contrato).subscribe(
         contrato => this.onSaveSuccess(),
         error => this.alertService.error(error.error));
    }
  }

  onSaveSuccess() {
    this.router.navigate(["/contrato"]);
    this.alertService.success("Guardado exitoso");
  }

  goBack(){
    this.router.navigate(["/contrato"]);
    this.alertService.success("Actualizado exitoso");
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
