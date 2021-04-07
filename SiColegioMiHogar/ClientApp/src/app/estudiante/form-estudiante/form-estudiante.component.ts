import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-estudiante',
  templateUrl: './form-estudiante.component.html',
  styleUrls: ['./form-estudiante.component.css']
})
export class FormEstudianteComponent implements OnInit {

  @Input() formGroupE: FormGroup;

  /*formGroupE = this.fb.group({
    ideEstudiante: ['', [Validators.required]],
    nomEstudiante: ['', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['', [Validators.required]],
    lugExpedicion: ['', [Validators.required]],
    insProcedencia: ['', [Validators.required]],
    dirResidencia: ['', [Validators.required]],
    celEstudiante: ['', [Validators.required]],
    tipSangre: ['', [Validators.required]],
    gradoEstudiante: ['', [Validators.required]],
    eps: ['', [Validators.required]],
    correo: ['', [Validators.required]],
    sexo: ['', [Validators.required]],
    tipoDocumento: ['', [Validators.required]],
    telEstudiante: ['', [Validators.required]]
  });*/

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute) { }
  ngOnInit() {
  }
  get ideEstudiante() {
    return this.formGroupE.get('ideEstudiante');
  }
  get nomEstudiante() {
    return this.formGroupE.get('nomEstudiante');
  }
  get fecNacimiento() {
    return this.formGroupE.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroupE.get('lugNacimiento');
  }
  get lugExpedicion() {
    return this.formGroupE.get('lugExpedicion');
  }
  get insProcedencia() {
    return this.formGroupE.get('insProcedencia');
  }
  get dirResidencia() {
    return this.formGroupE.get('dirResidencia');
  }
  get celEstudiante() {
    return this.formGroupE.get('celEstudiante');
  }
  get tipSangre() {
    return this.formGroupE.get('tipSangre');
  }
  get gradoEstudiante() {
    return this.formGroupE.get('gradoEstudiante');
  }
  get eps() {
    return this.formGroupE.get('eps');
  }
  get correo() {
    return this.formGroupE.get('correo');
  }
  get sexo() {
    return this.formGroupE.get('sexo');
  }
  get tipoDocumento() {
    return this.formGroupE.get('tipoDocumento');
  }
  get telEstudiante() {
    return this.formGroupE.get('telEstudiante');
  }
}
