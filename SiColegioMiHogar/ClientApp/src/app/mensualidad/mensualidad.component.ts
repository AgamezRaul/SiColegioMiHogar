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
  
  id: number,
  mes: number,
  diaPago: number,
  fechaPago: Date,
  valorMensualidad: number,
  descuentoMensualidad: number,
  abono: number,
  estado: string,
  idMatricula: number
}
export interface IMensualidad2 {
  id: number,
  estudiante: string,
  mes: number,
  valorMensualidad: number,
  descuentoMensualidad: number,
  abono: number,
  deuda: number,
  estado: string,
  totalMensualidad: number,
  correo: string
}
