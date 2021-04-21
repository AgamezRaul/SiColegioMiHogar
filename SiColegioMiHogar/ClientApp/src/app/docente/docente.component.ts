import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-docente',
  templateUrl: './docente.component.html',
  styleUrls: ['./docente.component.css']
})
export class DocenteComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  
}

export interface IDocente {
  id: number,
  nombreCompleto: string,
  numTarjetaProf: number,
  cedula: number,
  celular: number,
  correo: string,
  direccion: string
}

export interface IDocente2 {
  id: number,
  nombreCompleto: string,
  numTarjetaProf: number,
  cedula: number,
  celular: number,
  correo: string,
  direccion: string
}
