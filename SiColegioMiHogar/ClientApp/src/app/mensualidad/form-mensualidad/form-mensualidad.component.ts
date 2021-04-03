import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-mensualidad',
  templateUrl: './form-mensualidad.component.html',
  styleUrls: ['./form-mensualidad.component.css']
})
export class FormMensualidadComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute) { }
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


