import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/login.service';

@Component({
  selector: 'app-docente',
  templateUrl: './docente.component.html',
  styleUrls: ['./docente.component.css']
})
export class DocenteComponent implements OnInit {

  constructor(private loginService: LoginService) { }
  role: string;
  ngOnInit(): void {
    const usuario = JSON.parse(localStorage.getItem('user'));
    this.role = usuario["tipoUsuario"];
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
