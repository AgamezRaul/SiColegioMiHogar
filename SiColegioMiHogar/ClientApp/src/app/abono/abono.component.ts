import { Component, OnInit } from '@angular/core';
import { Data } from '@angular/router';

@Component({
  selector: 'app-abono',
  templateUrl: './abono.component.html',
  styleUrls: ['./abono.component.css']
})
export class AbonoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
export interface IAbono {
  id: number,
  mes: number,
  fechaPago: Date,
  valorAbono: number,
  estadoAbono: string,
  idMensualidad: number

}
export interface IAbonoVista {
  id: number,
  estudiante: string,
  fechaPago: Date,
  valorAbono: number,
  estadoAbono: string,
  valorMAtricula: number,
  deuda: number

}
