import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-responsable-padre',
  templateUrl: './form-responsable-padre.component.html',
  styleUrls: ['./form-responsable-padre.component.css']
})
export class FormResponsablePadreComponent implements OnInit {

  @Input() formGroupP: FormGroup;

  /*formGroupP = this.fb.group({
    ideResponsablePadre: ['', [Validators.required]],
    nomResponsablePadre: ['', [Validators.required]],
    fecNacimientoPadre: ['', [Validators.required]],
    lugNacimientoPadre: ['', [Validators.required]],
    lugExpedicionPadre: ['', [Validators.required]],
    tipDocumentoPadre: ['', [Validators.required]],
    celResponsablePadre: ['', [Validators.required]],
    profResponsablePadre: ['', [Validators.required]],
    ocuResponsablePadre: ['', [Validators.required]],
    entResonsablePadre: ['', [Validators.required]],
    celEmpresaPadre: ['', [Validators.required]],
    tipoResponsablePadre: ['', [Validators.required]],
    correoPadre: ['', [Validators.required]],
    acudientePadre: ['', [Validators.required]]
  });*/

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  
  ngOnInit() {
  }

  get ideResponsable() {
    return this.formGroupP.get('ideResponsable');
  }
  get nomResponsable() {
    return this.formGroupP.get('nomResponsable');
  }
  get fecNacimiento() {
    return this.formGroupP.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroupP.get('lugNacimiento');
  }
  get lugExpedicion() {
    return this.formGroupP.get('lugExpedicion');
  }
  get tipDocumento() {
    return this.formGroupP.get('tipDocumento');
  }
  get celResponsable() {
    return this.formGroupP.get('celResponsable');
  }
  get profResponsable() {
    return this.formGroupP.get('profResponsable');
  }
  get ocuResponsable() {
    return this.formGroupP.get('ocuResponsable');
  }
  get entResponsable() {
    return this.formGroupP.get('entResponsable');
  }
  get celEmpresa() {
    return this.formGroupP.get('celEmpresa');
  }
  get tipoResponsable() {
    return this.formGroupP.get('tipoResponsable');
  }
  get correo() {
    return this.formGroupP.get('correo');
  }
  get acudiente() {
    return this.formGroupP.get('acudiente');
  }



























  /*
  get ideResponsablePadre() {
    return this.formGroupP.get('ideResponsablePadre');
  }
  get nomResponsablePadre() {
    return this.formGroupP.get('nomResponsablePadre');
  }
  get fecNacimientoPadre() {
    return this.formGroupP.get('fecNacimientoPadre');
  }
  get lugNacimientoPadre() {
    return this.formGroupP.get('lugNacimientoPadre');
  }
  get lugExpedicionPadre() {
    return this.formGroupP.get('lugExpedicionPadre');
  }
  get tipDocumentoPadre() {
    return this.formGroupP.get('tipDocumentoPadre');
  }
  get celResponsablePadre() {
    return this.formGroupP.get('celResponsablePadre');
  }
  get profResponsablePadre() {
    return this.formGroupP.get('profResponsablePadre');
  }
  get ocuResponsablePadre() {
    return this.formGroupP.get('ocuResponsablePadre');
  }
  get entResonsablePadre() {
    return this.formGroupP.get('entResonsablePadre');
  }
  get celEmpresaPadre() {
    return this.formGroupP.get('celEmpresaPadre');
  }
  get tipoResponsablePadre() {
    return this.formGroupP.get('tipoResponsablePadre');
  }
  get correoPadre() {
    return this.formGroupP.get('correoPadre');
  }
  get acudientePadre() {
    return this.formGroupP.get('acudientePadre');
  }
  */
}
