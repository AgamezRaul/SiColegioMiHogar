import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-madre',
  templateUrl: './form-responsable-madre.component.html',
  styleUrls: ['./form-responsable-madre.component.css']
})
export class FormResponsableMadreComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    ideResponsableMadre: ['', [Validators.required]],
    nomResponsableMadre: ['', [Validators.required]],
    fechaNacimientoMadre: ['', [Validators.required]],
    lugNacimientoMadre: ['', [Validators.required]],
    lugExpedicionMadre: ['', [Validators.required]],
    tipoDocumentoMadre: ['', [Validators.required]],
    celResponsableMadre: ['', [Validators.required]],
    profResponsableMadre: ['', [Validators.required]],
    ocuResponsableMadre: ['', [Validators.required]],
    entResponsableMadre: ['', [Validators.required]],
    celEmpresaMadre: ['', [Validators.required]],
    tipoResponsableMadre: ['', [Validators.required]],
    correoMadre: ['', [Validators.required]],
    acudienteMadre: ['', [Validators.required]]
  })

  ngOnInit() {
  }

  get ideResponsableMadre() {
    return this.formGroup.get('ideResponsableMadre');
  }
  get nomResponsableMadre() {
    return this.formGroup.get('nomResponsableMadre');
  }
  get fecNacimientoMadre() {
    return this.formGroup.get('fecNacimientoMadre');
  }
  get lugNacimientoMadre() {
    return this.formGroup.get('lugNacimientoMadre');
  }
  get tipDocumentoMadre() {
    return this.formGroup.get('tipDocumentoMadre');
  }
  get celResponsableMadre() {
    return this.formGroup.get('celResponsableMadre');
  }
  get profResponsableMadre() {
    return this.formGroup.get('profResponsableMadre');
  }
  get ocuResponsableMadre() {
    return this.formGroup.get('ocuResponsableMadre');
  }
  get entResponsableMadre() {
    return this.formGroup.get('entResponsableMadre');
  }
  get celEmpresaMadre() {
    return this.formGroup.get('celEmpresaMadre');
  }
  get tipoResponsableMadre() {
    return this.formGroup.get('tipoResponsableMadre');
  }
  get correoMadre() {
    return this.formGroup.get('correoMadre');
  }
  get acudienteMadre() {
    return this.formGroup.get('acudienteMadre');
  }
}
