import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IAbono } from '../abono.component';
import { AbonoService } from '../abono.service';
import { formatCurrency, getCurrencySymbol, Location } from '@angular/common';
@Component({
  selector: 'app-form-abono',
  templateUrl: './form-abono.component.html',
  styleUrls: ['./form-abono.component.css']
})
export class FormAbonoComponent implements OnInit {

  constructor(private fb: FormBuilder, private abonoService: AbonoService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private mensaje: MensajesModule) { }
  modoEdicion: boolean = false;
  id: number;
  idAbono: number;
  ValorAbonoChange: string;
  formGroup = this.fb.group({
    valorAbono: ['', [Validators.required, Validators.pattern(/^[0-9]\d{0,20}$/)]]
  });
  ngOnInit(): void {

    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-abono') {
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

        if (params["idAbono"] == undefined) {
          return;
        }
        this.idAbono = parseInt(params["idAbono"]);
        this.abonoService.getAbono(this.idAbono)
          .subscribe(abono => this.cargarFormulario(abono),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
        //validar cuando es repetida para avisarle al usuario
      });
    }

  }
  cargarFormulario(abono: IAbono) {
    this.formGroup.patchValue({
      valorAbono: abono.valorAbono,
    });
  }
  save() {
    let abono: IAbono = Object.assign({}, this.formGroup.value);

    abono.valorAbono = parseInt(abono.valorAbono.toString());

    if (this.modoEdicion) {
      abono.id = this.idAbono;
      if (this.formGroup.valid) {
        this.abonoService.updateAbono(abono)
          .subscribe(abono => this.goBack(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Edicion no valida');
      }

    }
    else {

      abono.idMensualidad = this.id;
      console.table(abono); //ver mensualidad por consola
      if (this.formGroup.valid) {
        this.abonoService.createAbono(abono)
          .subscribe(abono => this.onSaveSuccess(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Registro no valido');
      }
    }


  }
  onSaveSuccess() {
    this.router.navigate(["/consultar-abono/" + this.id]);
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Abono Registrado correctamente');
  }

  goBack(): void {
    this.location.back();
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Abono editado correctamente');
  }
  updateValueValorAbono(value: string) {
    let val = parseInt(value, 10);
    if (Number.isNaN(val)) {
      val = 0;
    }
    //this.ValorMensualidadChange = formatCurrency(val, 'es-CO', getCurrencySymbol('COP', 'wide'));
    this.ValorAbonoChange = new Intl.NumberFormat('en-US', {
      currency: 'USD',
      style: 'decimal',
    }).format(val); // '100'
    console.log(this.ValorAbonoChange);
  }
  get valorAbono() {
    return this.formGroup.get('valorAbono');
  }
}
