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
  mes: string,
  deuda: number,
  estado: string,
  año: number,
  idMatricula: number
 
}
export interface IMensualidadVista {
  id: number,
  estudiante: string,
  mes: string,
  deuda: number,
  estado: string,
  valorMensualidad:number,
  correo: string

}

