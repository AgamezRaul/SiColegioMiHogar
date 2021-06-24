import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from './usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {
  usuarios: IUsuario[];
  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }
}
export interface IUsuario {
  id: number,
  correo: string,
  primerNombre: string,
  segundoNombre: string,
  primerApellido: string,
  segundoApellido: string,
  identificacion: string,
  password: string,
  tipoUsuario: string
}

