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

  id: number;

  formGroup = this.fb.group({
    mes: ['', [Validators.required]],
    diaPago: ['', [Validators.required]],
    fechaPago: ['', [Validators.required]],
    valorMensualidad:  ['', [Validators.required]],
    descuentoMensualidad: ['', [Validators.required]],
    abono: ['', [Validators.required]],
    estado: ['', [Validators.required]],
    idMatricula: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.id = parseInt(params["id"]);
    })
  }
  save() {
    let mensualidad: IMensualidad = Object.assign({}, this.formGroup.value);
    mensualidad.idMatricula = this.id;
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
  get estado() {
    return this.formGroup.get('estado');
  }
  get idMatricula() {
    return this.formGroup.get('idMatricula');
  }
  
}


