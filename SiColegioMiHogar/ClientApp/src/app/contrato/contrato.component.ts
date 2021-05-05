import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contrato',
  templateUrl: './contrato.component.html',
  styleUrls: ['./contrato.component.css']
})
export class ContratoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
 
}
export interface IContrato {
  id: number,
  fechaInicio: Date,
  fechaFin: Date,
  sueldo: number,
  idDocente: number
}
