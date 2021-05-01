import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nota-periodo',
  templateUrl: './nota-periodo.component.html',
  styleUrls: ['./nota-periodo.component.css']
})
export class NotaPeriodoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface INotaPeriodo {
  id: number,
  nota: number,
  observacion: string,
  idPeriodo: number,
  nombrePeriodo: string,
  idMateria: number,
  nombreMateria: string
}

export interface INotaPeriodo2 {
  id: number,
  nota: number,
  observacion: string,
  idPeriodo: number,
  nombrePeriodo: string,
  idMateria: number,
  nombreMateria: string
}
