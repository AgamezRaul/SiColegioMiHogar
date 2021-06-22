import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { IContrato } from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { DocenteService } from '../../docente/docente.service';
import { IDocente } from '../../docente/docente.component';
import Swal from 'sweetalert2';
import { MensajesModule } from '../../mensajes/mensajes.module';

@Component({
  selector: 'app-form-contrato',
  templateUrl: './form-contrato.component.html',
  styleUrls: ['./form-contrato.component.css']
})
export class FormContratoComponent implements OnInit {

  listaDocentes: IDocente[];
  SueldoChange: string;
  constructor(private fb: FormBuilder, private contratoService: ContratoService,
    private router: Router, private activatedRoute: ActivatedRoute, private location: Location,
    private docenteService: DocenteService, private mensaje: MensajesModule) { }
  modoEdicion: boolean = false;
  idDocente: number;
  formGroup = this.fb.group({
    fechaInicio: ['', [Validators.required]],
    fechaFin: ['', [Validators.required]],
    sueldo: ['', [Validators.required, Validators.pattern(/^[0-9]\d{0,20}$/)]],
    idDocente: ['', [Validators.required]]
  });
  ngOnInit(): void {
    this.docenteService.getDocentesEstado()
      .subscribe(docentes => this.llenarDocentes(docentes),
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));

    this.activatedRoute.params.subscribe(params => {
      if (params["idDocente"] == undefined) {
        return;
      }
      this.modoEdicion = true;
      this.idDocente = params["idDocente"];
      this.contratoService.getContrato(this.idDocente)
        .subscribe(contrato => this.cargarFormulario(contrato)),
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString());
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
     contrato.sueldo = parseInt(contrato.sueldo.toString());
     console.log(contrato.idDocente);
     if (this.modoEdicion) {//editar el registro
           if (this.formGroup.valid) {
              this.contratoService.updateContrato(contrato)
              .subscribe(contrato => this.goBack(),
                error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
            }
     } else {//crea
       console.log(contrato);
       this.contratoService.createContrato(contrato).subscribe(
         contrato => this.onSaveSuccess(),
         error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
    }
  }

  onSaveSuccess() {
    this.router.navigate(["/contrato"]);
    this.mensaje.mensajeAlertaCorrecto('¡Exito!', 'Contrato guardado exitosamente');
  }

  goBack(){
    this.router.navigate(["/contrato"]);
    this.mensaje.mensajeAlertaCorrecto('¡Exito!', 'Contrato actualizado exitosamente');
  }
  updateValueSueldo(value: string) {
    let val = parseInt(value, 10);
    if (Number.isNaN(val)) {
      val = 0;
    }
    this.SueldoChange = new Intl.NumberFormat('en-US', {
      currency: 'USD',
      style: 'decimal',
    }).format(val); // '100'
    console.log(this.SueldoChange);
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
