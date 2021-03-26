import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-acudiente',
  templateUrl: './form-responsable-acudiente.component.html',
  styleUrls: ['./form-responsable-acudiente.component.css']
})
export class FormResponsableAcudienteComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    ideResponsableAcudiente: ['', [Validators.required]],
    nomResponsableAcudiente: ['', [Validators.required]],
    fechaNacimientoAcudiente: ['', [Validators.required]],
    lugNacimientoAcudiente: ['', [Validators.required]],
    lugExpedicionAcudiente: ['', [Validators.required]],
    tipoDocumentoAcudiente: ['', [Validators.required]],
    celResponsableAcudiente: ['', [Validators.required]],
    profResponsableAcudiente: ['', [Validators.required]],
    ocuResponsableAcudiente: ['', [Validators.required]],
    entResponsableAcudiente: ['', [Validators.required]],
    celEmpresaAcudiente: ['', [Validators.required]],
    tipoResponsableAcudiente: ['', [Validators.required]],
    correoAcudiente: ['', [Validators.required]]
  })

  ngOnInit() {
  }
  get ideResponsableAcudiente() {
    return this.formGroup.get('ideResponsableAcudiente');
  }
  get nomResponsableAcudiente() {
    return this.formGroup.get('nomResponsableAcudiente');
  }
  get fecNacimientoAcudiente() {
    return this.formGroup.get('fecNacimientoAcudiente');
  }
  get lugNacimientoAcudiente() {
    return this.formGroup.get('lugNacimientoAcudiente');
  }
  get tipDocumentoAcudiente() {
    return this.formGroup.get('tipDocumentoAcudiente');
  }
  get celResponsableAcudiente() {
    return this.formGroup.get('celResponsableAcudiente');
  }
  get profResponsableAcudiente() {
    return this.formGroup.get('profResponsableAcudiente');
  }
  get ocuResponsableAcudiente() {
    return this.formGroup.get('ocuResponsableAcudiente');
  }
  get entResponsableAcudiente() {
    return this.formGroup.get('entResponsableAcudiente');
  }
  get celEmpresaAcudiente() {
    return this.formGroup.get('celEmpresaAcudiente');
  }
  get tipoResponsableAcudiente() {
    return this.formGroup.get('tipoResponsableAcudiente');
  }
  get correoAcudiente() {
    return this.formGroup.get('correoAcudiente');
  }

}

