import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estudiante-curso',
  templateUrl: './estudiante-curso.component.html',
  styleUrls: ['./estudiante-curso.component.css']
})
export class EstudianteCursoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface IEstudianteCurso {
  id: number,
  idEstudiante: number,
  idCurso: number
}
