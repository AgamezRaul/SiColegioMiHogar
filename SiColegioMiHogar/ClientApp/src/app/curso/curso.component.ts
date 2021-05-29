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
  id: number,
  nombre: string,
  maxEstudiantes: number,
  idDirectorDocente: number,
  letra: string
}

export interface ICurso2 {
  id:number,
  nombreCurso: string,
  maximoEstudiantes: number,
  docente: string,
  letra: string
}
