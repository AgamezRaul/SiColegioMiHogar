import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-valor-mensualidad',
  templateUrl: './valor-mensualidad.component.html',
  styleUrls: ['./valor-mensualidad.component.css']
})
export class ValorMensualidadComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
export interface IValorMensualidad {
  id: number,
  fecha: Date,
  año: number,
  precioMensualidad: number,
  idGrado: number
}

