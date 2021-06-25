import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';
import { formatCurrency, getCurrencySymbol, Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { MensajesModule } from '../../mensajes/mensajes.module';
@Component({
  selector: 'app-form-mensualidad',
  templateUrl: './form-mensualidad.component.html',
  styleUrls: ['./form-mensualidad.component.css']
})
export class FormMensualidadComponent implements OnInit {
  constructor(private fb: FormBuilder, private mensualidadService: MensualidadService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location,  private mensaje: MensajesModule) { }
  modoEdicion: boolean = false;
  id: number;
  idMensu: number;
  DeudaChange: string;
  formGroup = this.fb.group({
    mes: ['', [Validators.required]],
    deuda: ['', [Validators.required, Validators.pattern(/^[0-9]\d{0,20}$/)]]
  });

  ngOnInit(): void {

    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-mensualidad') {
      this.modoEdicion = false;
      console.log("Registando");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
      });
    }
    else {
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idMensualidad"] == undefined) {
          return;
        }
        this.idMensu = parseInt(params["idMensualidad"]);
        this.mensualidadService.getMensualidad(this.idMensu)
          .subscribe(mensualidad => this.cargarFormulario(mensualidad),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
        //validar cuando es repetida para avisarle al usuario
      });
    }
   
  }
  cargarFormulario(mensualiadad: IMensualidad) {
    this.formGroup.patchValue({
      mes: mensualiadad.mes,
      deuda: mensualiadad.deuda,
     
    });
  }
  save() {
    let mensualidad: IMensualidad = Object.assign({}, this.formGroup.value);

    mensualidad.deuda = parseInt(mensualidad.deuda.toString());
    

    if (this.modoEdicion) {
      mensualidad.id = this.idMensu;
      if (this.formGroup.valid) {
        this.mensualidadService.updateMensualidad(mensualidad)
          .subscribe(mensualidad => this.goBack(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Edicion no valida');
      }
      
    }
    else {
    
      mensualidad.idMatricula = this.id;
      console.table(mensualidad); //ver mensualidad por consola
      if (this.formGroup.valid) {
        this.mensualidadService.createMensualidad(mensualidad)
          .subscribe(mensualidad => this.onSaveSuccess(),
          error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!','Registro no valido');
      }
         }
    

  }
 onSaveSuccess() {
   this.router.navigate(["/consultar-mensualidad/" + this.id]);
   this.mensaje.mensajeAlertaCorrecto('Exitoso!','Mensualidad guardada correctamente');
  }
 
  goBack(): void{
    this.location.back();
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Mensualidad editada correctamente');
  }

  
  updateValueDeuda(value: string) {
    let val = parseInt(value, 10);
    if (Number.isNaN(val)) {
      val = 0;
    }
    //this.ValorMensualidadChange = formatCurrency(val, 'es-CO', getCurrencySymbol('COP', 'wide'));
    this.DeudaChange = new Intl.NumberFormat('en-US', {
      currency: 'USD',
      style: 'decimal',
    }).format(val); // '100'
    console.log(this.DeudaChange);
  }
  get mes() {
    return this.formGroup.get('mes');
  }
  get deuda() {
    return this.formGroup.get('deuda');
  }
  
}


