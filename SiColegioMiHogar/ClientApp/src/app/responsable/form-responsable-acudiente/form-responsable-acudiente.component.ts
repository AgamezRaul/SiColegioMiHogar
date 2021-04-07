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

  /*formGroupA = this.fb.group({
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
  });*/

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
  }
  
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
  }
}

