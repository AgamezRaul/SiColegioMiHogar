import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-materia',
  templateUrl: './materia.component.html',
  styleUrls: ['./materia.component.css']
})
export class MateriaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export interface IMateria {
  id: number,
  nombreMateria: string,
  idDocente: number,
  idCurso: number
}
