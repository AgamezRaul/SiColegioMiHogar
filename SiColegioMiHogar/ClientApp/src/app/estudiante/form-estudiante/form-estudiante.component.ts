import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form-estudiante',
  templateUrl: './form-estudiante.component.html',
  styleUrls: ['./form-estudiante.component.css']
})
export class FormEstudianteComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
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
  });

  ngOnInit() {
  }

  get ideEstudiante() {
    return this.formGroup.get('ideEstudiante');
  }
  get nomEstudiante() {
    return this.formGroup.get('nomEstudiante');
  }
  get fecNacimiento() {
    return this.formGroup.get('fecNacimiento');
  }
  get lugNacimiento() {
    return this.formGroup.get('lugNacimiento');
  }
  get lugExpedicion() {
    return this.formGroup.get('lugExpedicion');
  }
  get insProcedencia() {
    return this.formGroup.get('insProcedencia');
  }
  get dirResidencia() {
    return this.formGroup.get('dirResidencia');
  }
  get celEstudiante() {
    return this.formGroup.get('celEstudiante');
  }
  get tipSangre() {
    return this.formGroup.get('tipSangre');
  }
  get gradoEstudiante() {
    return this.formGroup.get('gradoEstudiante');
  }
  get eps() {
    return this.formGroup.get('eps');
  }
  get correo() {
    return this.formGroup.get('correo');
  }
  get sexo() {
    return this.formGroup.get('sexo');
  }
  get tipoDocumento() {
    return this.formGroup.get('tipoDocumento');
  }
  get telEstudiante() {
    return this.formGroup.get('telEstudiante');
  }
}
