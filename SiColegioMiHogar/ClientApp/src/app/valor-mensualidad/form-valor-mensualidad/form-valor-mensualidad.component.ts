import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IValorMensualidad } from '../valor-mensualidad.component';
import { ValorMensualidadService } from '../valor-mensualidad.service';
import { formatCurrency, getCurrencySymbol, Location } from '@angular/common';
import { IGrado } from '../../grado/grado.component';
import { GradoService } from '../../grado/grado.service';
@Component({
  selector: 'app-form-valor-mensualidad',
  templateUrl: './form-valor-mensualidad.component.html',
  styleUrls: ['./form-valor-mensualidad.component.css']
})
export class FormValorMensualidadComponent implements OnInit {
  constructor(private fb: FormBuilder, private valorMensualidadService: ValorMensualidadService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private mensaje: MensajesModule, private gradoService: GradoService) { }
  modoEdicion: boolean = false;
  PrecioValorMensualidadChange: string;
  id: number;
  idMensu: number;
  ListaGrados: IGrado[] = [];
  formGroup = this.fb.group({
    fecha: ['', [Validators.required]],
    precioMensualidad: ['', [Validators.required, Validators.pattern(/^[0-9]\d{0,20}$/)]],
    idGrado: ['', [Validators.required]]
  });
  ngOnInit(): void {

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] != undefined) {
        this.modoEdicion = true;
        this.id = parseInt(params["id"]);
        console.log("editando")
        this.valorMensualidadService.getValorMensualidad(this.id)
          .subscribe(valorMensualidad => this.cargarFormulario(valorMensualidad),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {

       
        this.modoEdicion = false;
        console.log("Registando");
        this.gradoService.getGrados().subscribe(grado => this.LLenarGrados(grado),
          error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      }
    });
  }
  cargarFormulario(valorMensualiadad: IValorMensualidad) {
    this.formGroup.patchValue({
      fecha: valorMensualiadad.fecha,
      precioMensualidad: valorMensualiadad.precioMensualidad,
      idGrado: valorMensualiadad.idGrado,
    });
  }
  save() {
    let valorMensualidad: IValorMensualidad = Object.assign({}, this.formGroup.value);
    valorMensualidad.precioMensualidad = parseInt(valorMensualidad.precioMensualidad.toString());
    if (this.modoEdicion) {
      valorMensualidad.id = this.id;
      if (this.formGroup.valid) {
        this.valorMensualidadService.updateValorMensualidad(valorMensualidad)
          .subscribe(valorMensualidad => this.goBack(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Edicion no valida');
      }

    }
    else {
      console.table(valorMensualidad); //ver mensualidad por consola
      valorMensualidad.idGrado = parseInt(valorMensualidad.idGrado.toString());
      if (this.formGroup.valid) {
        this.valorMensualidadService.createValorMensualidad(valorMensualidad)
          .subscribe(valorMensualidad => this.onSaveSuccess(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Registro no valido');
      }
    }
  }
  onSaveSuccess() {
    this.location.back();
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Valor Mensualidad guardado correctamente');
  }

  goBack(): void {
    this.location.back();
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Valor Mensualidad editado correctamente');
  }
  LLenarGrados(grados: IGrado[]) {
    this.ListaGrados = grados;
  }
  updateValuePrecioValorMensualidad(value: string) {
    let val = parseInt(value, 10);
    if (Number.isNaN(val)) {
      val = 0;
    }
    //this.ValorMensualidadChange = formatCurrency(val, 'es-CO', getCurrencySymbol('COP', 'wide'));
    this.PrecioValorMensualidadChange = new Intl.NumberFormat('en-US', {
      currency: 'USD',
      style: 'decimal',
    }).format(val); // '100'
    console.log(this.PrecioValorMensualidadChange);
  }
  get fecha() {
    return this.formGroup.get('fecha');
  }
  get precioMensualidad() {
    return this.formGroup.get('precioMensualidad');
  }
  get idGrado() {
    return this.formGroup.get('idGrado');
  }
}
