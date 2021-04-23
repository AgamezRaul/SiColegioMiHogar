import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estudiante',
  templateUrl: './estudiante.component.html',
  styleUrls: ['./estudiante.component.css']
})
export class EstudianteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

export interface IEstudiante {
  id: number,
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
