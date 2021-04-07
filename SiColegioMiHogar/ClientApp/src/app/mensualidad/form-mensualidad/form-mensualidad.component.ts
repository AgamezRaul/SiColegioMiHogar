import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';

@Component({
  selector: 'app-form-mensualidad',
  templateUrl: './form-mensualidad.component.html',
  styleUrls: ['./form-mensualidad.component.css']
})
export class FormMensualidadComponent implements OnInit {

  constructor(private fb: FormBuilder, private mensualidadService: MensualidadService, private router: Router, private activatedRoute: ActivatedRoute) { }
  formGroup = this.fb.group({
    mes: ['', [Validators.required]],
    diaPago: ['', [Validators.required]],
    fechaPago: ['', [Validators.required]],
    valorMensualidad:  ['', [Validators.required]],
    descuentoMensualidad: ['', [Validators.required]],
    abono: ['', [Validators.required]],
    deuda: ['', [Validators.required]],
    estado: ['', [Validators.required]],
    idMatricula: ['', [Validators.required]],
    totalMensualidad: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }
  save() {
    let mensualidad: IMensualidad = Object.assign({}, this.formGroup.value);
    console.table(mensualidad); //ver mensualidad por consola
    this.mensualidadService.createMensualidad(mensualidad)
      .subscribe(mensualidad => this.onSaveSuccess());

  }
  onSaveSuccess() {
    this.router.navigate(["/"]);
  }
  get mes() {
    return this.formGroup.get('mes');
  }
  get diaPago() {
    return this.formGroup.get('diaPago');
  }
  get fechaPago() {
    return this.formGroup.get('fechaPago');
  }
  get valorMensualidad() {
    return this.formGroup.get('valorMensualidad');
  }
  get descuentoMensualidad() {
    return this.formGroup.get('descuentoMensualidad');
  }
  get abono() {
    return this.formGroup.get('abono');
  }
  get deuda() {
    return this.formGroup.get('deuda');
  }
  get estado() {
    return this.formGroup.get('estado');
  }
  get idMatricula() {
    return this.formGroup.get('idMatricula');
  }
  get totalMensualidad() {
    return this.formGroup.get('totalMensualidad');
  }
 

  
}


