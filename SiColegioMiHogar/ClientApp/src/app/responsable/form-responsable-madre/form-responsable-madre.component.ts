import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-madre',
  templateUrl: './form-responsable-madre.component.html',
  styleUrls: ['./form-responsable-madre.component.css']
})
export class FormResponsableMadreComponent implements OnInit {

  @Input() formGroupResponsable: FormGroup;

  /*formGroupM = this.fb.group({
    ideResponsableMadre: ['', [Validators.required]],
    nomResponsableMadre: ['', [Validators.required]],
    fechaNacimientoMadre: ['', [Validators.required]],
    lugNacimientoMadre: ['', [Validators.required]],
    lugExpedicionMadre: ['', [Validators.required]],
    tipDocumentoMadre: ['', [Validators.required]],
    celResponsableMadre: ['', [Validators.required]],
    profResponsableMadre: ['', [Validators.required]],
    ocuResponsableMadre: ['', [Validators.required]],
    entResponsableMadre: ['', [Validators.required]],
    celEmpresaMadre: ['', [Validators.required]],
    tipoResponsableMadre: ['', [Validators.required]],
    correoMadre: ['', [Validators.required]],
    acudienteMadre: ['', [Validators.required]]
  });*/

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  

  ngOnInit() {
  }
  get ideResponsable() {
    return this.formGroupResponsable.get('ideResponsableMadre');
  }
  get nomResponsable() {
    return this.formGroupResponsable.get('nomResponsableMadre');
  }
  get fecNacimiento() {
    return this.formGroupResponsable.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroupResponsable.get('lugNacimiento');
  }
  get tipDocumento() {
    return this.formGroupResponsable.get('tipDocumento');
  }
  get celResponsable() {
    return this.formGroupResponsable.get('celResponsable');
  }
  get profResponsable() {
    return this.formGroupResponsable.get('profResponsable');
  }
  get ocuResponsable() {
    return this.formGroupResponsable.get('ocuResponsable');
  }
  get entResponsable() {
    return this.formGroupResponsable.get('entResponsable');
  }
  get celEmpresa() {
    return this.formGroupResponsable.get('celEmpresa');
  }
  get tipoResponsable() {
    return this.formGroupResponsable.get('tipoResponsable');
  }
  get correo() {
    return this.formGroupResponsable.get('correo');
  }
  get acudiente() {
    return this.formGroupResponsable.get('acudiente');
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
