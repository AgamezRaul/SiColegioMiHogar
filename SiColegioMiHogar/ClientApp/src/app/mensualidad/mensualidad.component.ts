import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mensualidad',
  templateUrl: './mensualidad.component.html',
  styleUrls: ['./mensualidad.component.css']
})
export class MensualidadComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
export interface IMensualidad {
  mes: string,
  diaPago: number,
  fechaPago: Date,
  valorMensualidad: number,
  descuentoMensualidad: number,
  abono: number,
  deuda: number,
  estado: number,
  idMatricula: number,
  totalMensualidad: number
}