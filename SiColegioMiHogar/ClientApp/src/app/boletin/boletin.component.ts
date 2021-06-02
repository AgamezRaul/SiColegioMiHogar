import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-boletin',
  templateUrl: './boletin.component.html',
  styleUrls: ['./boletin.component.css']
})
export class BoletinComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
}

export interface IBoletin {
  id: number,
  idEstudiante: number,
  fechaGeneracion: Date,
  idPeriodo: number
}
