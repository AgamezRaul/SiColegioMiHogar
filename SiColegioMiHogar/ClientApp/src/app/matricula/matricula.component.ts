import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-matricula',
  templateUrl: './matricula.component.html',
  styleUrls: ['./matricula.component.css']
})
export class MatriculaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
export interface IMatricula {
  idMatricula: number,
  nomEstudiante: string,
  fecMatricula: Date
}
export interface IMatricula2 {
  id: number,
  fecConfirmacion: Date,
  idPreMatricula: number
}
