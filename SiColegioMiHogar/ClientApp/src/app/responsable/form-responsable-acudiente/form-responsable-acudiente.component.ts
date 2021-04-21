import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-acudiente',
  templateUrl: './form-responsable-acudiente.component.html',
  styleUrls: ['./form-responsable-acudiente.component.css']
})
export class FormResponsableAcudienteComponent implements OnInit {

  @Input() formGroupA: FormGroup;

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
  }
  get ideResponsable() {
    return this.formGroupA.get('ideResponsable');
  }
  get nomResponsable() {
    return this.formGroupA.get('nomResponsable');
  }
  get fecNacimiento() {
    return this.formGroupA.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroupA.get('lugNacimiento');
  }
  get tipDocumento() {
    return this.formGroupA.get('tipDocumento');
  }
  get celResponsable() {
    return this.formGroupA.get('celResponsable');
  }
  get profResponsable() {
    return this.formGroupA.get('profResponsable');
  }
  get ocuResponsable() {
    return this.formGroupA.get('ocuResponsable');
  }
  get entResponsable() {
    return this.formGroupA.get('entResponsable');
  }
  get celEmpresa() {
    return this.formGroupA.get('celEmpresa');
  }
  get tipoResponsable() {
    return this.formGroupA.get('tipoResponsable');
  }
  get correo() {
    return this.formGroupA.get('correo');
  }

























  /*
  get ideResponsableAcudiente() {
    return this.formGroupA.get('ideResponsableAcudiente');
  }
  get nomResponsableAcudiente() {
    return this.formGroupA.get('nomResponsableAcudiente');
  }
  get fecNacimientoAcudiente() {
    return this.formGroupA.get('fecNacimientoAcudiente');
  }
  get lugNacimientoAcudiente() {
    return this.formGroupA.get('lugNacimientoAcudiente');
  }
  get tipDocumentoAcudiente() {
    return this.formGroupA.get('tipDocumentoAcudiente');
  }
  get celResponsableAcudiente() {
    return this.formGroupA.get('celResponsableAcudiente');
  }
  get profResponsableAcudiente() {
    return this.formGroupA.get('profResponsableAcudiente');
  }
  get ocuResponsableAcudiente() {
    return this.formGroupA.get('ocuResponsableAcudiente');
  }
  get entResponsableAcudiente() {
    return this.formGroupA.get('entResponsableAcudiente');
  }
  get celEmpresaAcudiente() {
    return this.formGroupA.get('celEmpresaAcudiente');
  }
  get tipoResponsableAcudiente() {
    return this.formGroupA.get('tipoResponsableAcudiente');
  }
  get correoAcudiente() {
    return this.formGroupA.get('correoAcudiente');
  }*/
}

