import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GestionDeMateriasService } from './gestion-de-materias.service';

@Component({
  selector: 'app-gestion-de-materias',
  templateUrl: './gestion-de-materias.component.html',
  styleUrls: ['./gestion-de-materias.component.css']
})
export class GestionDeMateriasComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

export interface IMateria {

  IdMateria: number,
  NombreMateria: string,
  IdDocente: number,
  IdCurso: number
}

export interface IMateria2 {

  IdMateria: number,
  NombreMateria: string,
  IdDocente: number,
  IdCurso: number
}
