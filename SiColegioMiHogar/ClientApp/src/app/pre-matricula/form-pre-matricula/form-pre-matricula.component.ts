import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { IResponsable } from '../../responsable/responsable.component';

@Component({
  selector: 'app-form-pre-matricula',
  templateUrl: './form-pre-matricula.component.html',
  styleUrls: ['./form-pre-matricula.component.css']
})
export class FormPreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

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
  });*/

  formGroupResponsable = this.fb.group({
    ideResponsable: ['', [Validators.required]],
    nomResponsable: ['', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['', [Validators.required]],
    lugExpedicion: ['', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['', [Validators.required]],
    profResponsable: ['', [Validators.required]],
    ocuResponsable: ['', [Validators.required]],
    entResponsable: ['', [Validators.required]],
    celEmpresa: ['', [Validators.required]],
    tipoResponsable: ['', [Validators.required]],
    correo: ['', [Validators.required]],
    acudiente: ['', [Validators.required]]
  });
  responsables: IResponsable[];
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
    console.log(this.formGroupE, this.formGroupResponsable)
  }
}
export interface IPrematricula2 {
  nomEstudiante: string,
  fecPrematricula: Date,
  estado: string,
}

export interface IPrematricula {
  id: number,
  fecPrematricula: Date,
  idUsuario: number,
  estado: string,
  responsables: IResponsable[],
  iEstudiante: IEstudiante
}
