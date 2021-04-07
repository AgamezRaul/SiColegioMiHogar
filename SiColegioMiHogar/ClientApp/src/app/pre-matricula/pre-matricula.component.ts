import { Component, Input, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pre-matricula',
  templateUrl: './pre-matricula.component.html',
  styleUrls: ['./pre-matricula.component.css']
})
export class PreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  formGroupA = this.fb.group({
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

  formGroupM = this.fb.group({
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
  })

  formGroupP = this.fb.group({
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

  formGroupE = this.fb.group({
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

  save() {
    console.log(this.formGroupE, this.formGroupA, this.formGroupM, this.formGroupP)
  }
}
