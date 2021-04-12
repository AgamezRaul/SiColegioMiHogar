import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-docente',
  templateUrl: './docente.component.html',
  styleUrls: ['./docente.component.css']
})
export class DocenteComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  
}

export interface IDocente {
  id: number,
  nombre: string,
  numTar: number,
  cedula: number,
  celular: number,
  correo: string,
  direccion: string
}

export interface IDocente2 {
  id: number,
  nombre: string,
  numTar: number,
  cedula: number,
  celular: number,
  correo: string,
  direccion: string
}
