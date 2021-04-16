import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nota',
  templateUrl: './nota.component.html',
  styleUrls: ['./nota.component.css']
})
export class NotaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface INotaConsult{
  descripcion: string;
  notaAlumno: number;
  fechaNota: string;
  estudiante: string
  materia: string;
  periodo: string;
}

export interface INota{
  Descripcion: string 
  NotaAlumno: number
  IdEstudiante: number
  IdMateria: number
  IdPeriodo: number
}

export interface IEstudianteNota {
  ideEstudiante: string,
  nomEstudiante: string,
  fecNacimiento: Date,
  lugNacimiento: string,
  lugExpedicion: string,
  insProcedencia: string,
  dirResidencia: string,
  celEstudiante: string,
  tipSangre: string,
  gradoEstudiante: string,
  eps: string,
  correo: string,
  sexo: string,
  tipoDocumento: string,
  telEstudiante: string,
  idUsuario: number
}

export interface IPeriodoNota {
  id: number,
  numeroPeriodo: number,
  nombrePeriodo: string,
  fechaInicio: Date,
  fechaFin: Date
}

export interface MateriaNota {
  id: number;
  idMateria: number;
  nombreMateria: string;
  idDocente: number;
  idCurso: number;
}
