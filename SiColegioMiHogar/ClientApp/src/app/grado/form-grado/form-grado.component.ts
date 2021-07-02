import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IGrado } from '../grado.component';
import { GradoService } from '../grado.service';
import { formatCurrency, getCurrencySymbol, Location } from '@angular/common';

@Component({
  selector: 'app-form-grado',
  templateUrl: './form-grado.component.html',
  styleUrls: ['./form-grado.component.css']
})
export class FormGradoComponent implements OnInit {

  constructor(private fb: FormBuilder, private gradoService: GradoService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private mensaje: MensajesModule) { }
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }

  save() {
    let grado: IGrado = Object.assign({}, this.formGroup.value);
      console.table(grado); //ver grado por consola
      if (this.formGroup.valid) {
        this.gradoService.createGrado(grado)
          .subscribe(mensualidad => this.goBack(),
            error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
      } else {
        this.mensaje.mensajeAlertaError('¡Error!', 'Registro no valido');
      }
  }
  goBack(): void {
    this.location.back();
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Grado registrado correctamente');
  }
  get nombre() {
    return this.formGroup.get('nombre');
  }
}
