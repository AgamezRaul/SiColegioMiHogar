import { Component, OnInit } from '@angular/core';
import { IEstudiante } from '../estudiante/estudiante.component';

@Component({
  selector: 'app-responsable',
  templateUrl: './responsable.component.html',
  styleUrls: ['./responsable.component.css']
})
export class ResponsableComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

export interface IPadre {
  ideResponsablePadre: string,
  nomResponsablePadre: string,
  fecNacimientoPadre: string,
  lugNacimientoPadre: string,
  lugExpedicionPadre: string,
  tipDocumentoPadre: string,
  celResponsablePadre: number,
  profResponsablePadre: string,
  ocuResponsablePadre: string,
  entResonsablePadre: string,
  celEmpresaPadre: number,
  tipoResponsablePadre: string,
  correoPadre: string,
  acudientePadre: string,
  idEstudiantePadre: number,
  idPrematriculaPadre: number
}
export interface IMadre {
  ideResponsableMadre: string,
  nomResponsableMadre: string,
  fecNacimientoMadre: string,
  lugNacimientoMadre: string,
  lugExpedicionMadre: string,
  tipDocumentoMadre: string,
  celResponsableMadre: number,
  profResponsableMadre: string,
  ocuResponsableMadre: string,
  entResonsableMadre: string,
  celEmpresaMadre: number,
  tipoResponsableMadre: string,
  correoMadre: string,
  acudienteMadre: string,
  idEstudianteMadre: number,
  idPrematriculaMadre: number
}
export interface IAcudiente {
  ideResponsableAcudiente: string,
  nomResponsableAcudiente: string,
  fecNacimientoAcudiente: string,
  lugNacimientoAcudiente: string,
  lugExpedicionAcudiente: string,
  tipDocumentoAcudiente: string,
  celResponsableAcudiente: number,
  profResponsableAcudiente: string,
  ocuResponsableAcudiente: string,
  entResonsableAcudiente: string,
  celEmpresaAcudiente: number,
  tipoResponsableAcudiente: string,
  correoAcudiente: string,
  acudienteAcudiente: string,
  idEstudianteAcudiente: number,
  idPrematriculaAcudiente: number
}

export interface IPrematricula {
  iPadre: IPadre,
  iMadre: IMadre,
  iAcudiente: IAcudiente,
  iEstudiante: IEstudiante
}
