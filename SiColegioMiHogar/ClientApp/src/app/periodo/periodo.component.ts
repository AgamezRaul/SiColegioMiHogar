import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-periodo',
  templateUrl: './periodo.component.html',
  styleUrls: ['./periodo.component.css']
})
export class PeriodoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface IPeriodo {
  id: number,
  numeroPeriodo: number,
  nombrePeriodo: string,
  fechaInicio: Date,
  fechaFin: Date
}
