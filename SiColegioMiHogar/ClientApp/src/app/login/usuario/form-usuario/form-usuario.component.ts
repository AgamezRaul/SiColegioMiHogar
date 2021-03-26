import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]],
    nomUsuario: ['', [Validators.required]],
    tipoUsuario: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }

  save() {
    let usuario: IUsuario = Object.assign({}, this.formGroup.value);
    console.table(usuario); //ver usuario por consola
    this.usuarioService.createEmpleado(usuario)
      .subscribe(empleado => this.onSaveSuccess());

  }
  onSaveSuccess() {
    this.router.navigate(["/"]);
  }

  get correo() {
    return this.formGroup.get('correo');
  }
  get password() {
    return this.formGroup.get('password');
  }
  get nomUsuario() {
    return this.formGroup.get('nomUsuario');
  }
  get tipoUsuario() {
    return this.formGroup.get('tipoUsuario');
  }
}
