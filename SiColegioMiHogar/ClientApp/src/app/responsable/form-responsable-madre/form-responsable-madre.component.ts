import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-madre',
  templateUrl: './form-responsable-madre.component.html',
  styleUrls: ['./form-responsable-madre.component.css']
})
export class FormResponsableMadreComponent implements OnInit {

  @Input() formGroupM: FormGroup;

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
  }
  get ideResponsable() {
    return this.formGroupM.get('ideResponsable');
  }
  get nomResponsable() {
    return this.formGroupM.get('nomResponsable');
  }
  get fecNacimiento() {
    return this.formGroupM.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroupM.get('lugNacimiento');
  }
  get lugExpedicion() {
    return this.formGroupM.get('lugExpedicion');
  }
  get tipDocumento() {
    return this.formGroupM.get('tipDocumento');
  }
  get celResponsable() {
    return this.formGroupM.get('celResponsable');
  }
  get profResponsable() {
    return this.formGroupM.get('profResponsable');
  }
  get ocuResponsable() {
    return this.formGroupM.get('ocuResponsable');
  }
  get entResponsable() {
    return this.formGroupM.get('entResponsable');
  }
  get celEmpresa() {
    return this.formGroupM.get('celEmpresa');
  }
  get tipoResponsable() {
    return this.formGroupM.get('tipoResponsable');
  }
  get correo() {
    return this.formGroupM.get('correo');
  }
  get acudiente() {
    return this.formGroupM.get('acudiente');
  }

























  /*
  get ideResponsableMadre() {
    return this.formGroupM.get('ideResponsableMadre');
  }
  get nomResponsableMadre() {
    return this.formGroupM.get('nomResponsableMadre');
  }
  get fechaNacimientoMadre() {
    return this.formGroupM.get('fechaNacimientoMadre');
  }
  get lugNacimientoMadre() {
    return this.formGroupM.get('lugNacimientoMadre');
  }
  get tipDocumentoMadre() {
    return this.formGroupM.get('tipDocumentoMadre');
  }
  get celResponsableMadre() {
    return this.formGroupM.get('celResponsableMadre');
  }
  get profResponsableMadre() {
    return this.formGroupM.get('profResponsableMadre');
  }
  get ocuResponsableMadre() {
    return this.formGroupM.get('ocuResponsableMadre');
  }
  get entResponsableMadre() {
    return this.formGroupM.get('entResponsableMadre');
  }
  get celEmpresaMadre() {
    return this.formGroupM.get('celEmpresaMadre');
  }
  get tipoResponsableMadre() {
    return this.formGroupM.get('tipoResponsableMadre');
  }
  get correoMadre() {
    return this.formGroupM.get('correoMadre');
  }
  get acudienteMadre() {
    return this.formGroupM.get('acudienteMadre');
  }*/
  
}
