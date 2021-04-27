import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface ICurso {
  nombre: string,
  maxEstudiantes: number,
  idDirectorDocente: number
}

export interface ICurso2 {
  nombreCurso: string,
  maximoEstudiantes: number,
  docente: string
}
