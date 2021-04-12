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
  MaxEst: number,
  idDirector: number
}

export interface ICurso2 {
  nombre: string,
  MaxEst: number,
  docente: string
}
