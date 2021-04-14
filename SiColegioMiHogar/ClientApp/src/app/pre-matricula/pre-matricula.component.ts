import { Component, Input, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IEstudiante } from '../estudiante/estudiante.component';
import { IResponsable } from '../responsable/responsable.component';

@Component({
  selector: 'app-pre-matricula',
  templateUrl: './pre-matricula.component.html',
  styleUrls: ['./pre-matricula.component.css']
})
export class PreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  ngOnInit() {

  }
}
export interface IPrematricula2 {
  idusuario: number,
  idPrematricula: number,
  nomEstudiante: string,
  fecPrematricula: Date,
  estado: string,
}

export interface IPrematricula {
  idPrematricula: number,
  idUsuario: number,
  responsables: IResponsable[],
  estudiante: IEstudiante
}
export interface IPrematricula3 {
  id: number,
  fecPrematricula: Date,
  estado: string,
  idUsuario: number,
  estudiante: IEstudiante,
  responsables: IResponsable[]
}
