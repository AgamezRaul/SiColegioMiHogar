import { Component, OnInit } from '@angular/core';
import { Data } from 'popper.js';

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

export interface IResponsable {
  ideResponsable: string,
  nomResponsable: string,
  fecNacimiento: Date,
  lugNacimiento: string,
  lugExpedicion: string,
  tipDocumento: string,
  celResponsable: string,
  profResponsable: string,
  ocuResponsable: string,
  entResponsable: string,
  celEmpresa: string,
  tipoResponsable: string,
  correo: string,
  acudiente: string,
  idUsuario: number
}
