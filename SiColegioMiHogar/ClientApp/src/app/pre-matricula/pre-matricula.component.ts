import { error } from '@angular/compiler/src/util';
import { Component, Input, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IEstudiante } from '../estudiante/estudiante.component';
import { LoginService } from '../login/login.service';
import { AlertService } from '../notifications/_services';
import { IResponsable } from '../responsable/responsable.component';

@Component({
  selector: 'app-pre-matricula',
  templateUrl: './pre-matricula.component.html',
  styleUrls: ['./pre-matricula.component.css']
})
export class PreMatriculaComponent implements OnInit {
  role: string;
  constructor(private fb: FormBuilder, private loginService: LoginService,
    private alertService: AlertService  ) { }
  ngOnInit() {
    const usuario = JSON.parse(localStorage.getItem('user'));
    this.role = usuario["tipoUsuario"];
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
