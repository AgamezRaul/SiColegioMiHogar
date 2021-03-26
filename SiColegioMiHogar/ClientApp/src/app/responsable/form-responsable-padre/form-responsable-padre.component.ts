import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-responsable-padre',
  templateUrl: './form-responsable-padre.component.html',
  styleUrls: ['./form-responsable-padre.component.css']
})
export class FormResponsablePadreComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
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
  });
  ngOnInit() {
  }

  get ideResponsablePadre() {
    return this.formGroup.get('ideResponsablePadre');
  }
  get nomResponsablePadre() {
    return this.formGroup.get('nomResponsablePadre');
  }
  get fecNacimientoPadre() {
    return this.formGroup.get('fecNacimientoPadre');
  }
  get lugNacimientoPadre() {
    return this.formGroup.get('lugNacimientoPadre');
  }
  get lugExpedicionPadre() {
    return this.formGroup.get('lugExpedicionPadre');
  }
  get tipDocumentoPadre() {
    return this.formGroup.get('tipDocumentoPadre');
  }
  get celResponsablePadre() {
    return this.formGroup.get('celResponsablePadre');
  }
  get profResponsablePadre() {
    return this.formGroup.get('profResponsablePadre');
  }
  get ocuResponsablePadre() {
    return this.formGroup.get('ocuResponsablePadre');
  }
  get entResonsablePadre() {
    return this.formGroup.get('entResonsablePadre');
  }
  get celEmpresaPadre() {
    return this.formGroup.get('celEmpresaPadre');
  }
  get tipoResponsablePadre() {
    return this.formGroup.get('tipoResponsablePadre');
  }
  get correoPadre() {
    return this.formGroup.get('correoPadre');
  }
  get acudientePadre() {
    return this.formGroup.get('acudientePadre');
  }
}
