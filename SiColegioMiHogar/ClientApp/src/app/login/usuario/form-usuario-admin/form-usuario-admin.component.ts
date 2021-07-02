import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-form-usuario-admin',
  templateUrl: './form-usuario-admin.component.html',
  styleUrls: ['./form-usuario-admin.component.css']
})
export class FormUsuarioAdminComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private location: Location) { }
  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]],
    tipoUsuario: ['Admin', [Validators.required]]
  });

  ngOnInit(): void {
  }
  save() {
    let usuario: IUsuario = Object.assign({}, this.formGroup.value);
    console.table(usuario); //ver usuario por consola
    this.usuarioService.createUsuario(usuario)
      .subscribe(usuario => this.onSaveSuccess(),
        error => this.alertService.error(error.error));

  }
  onSaveSuccess() {
    this.location.back();
    this.alertService.success("Usuario administrado registrado correctamente");
  }
  get correo() {
    return this.formGroup.get('correo');
  }
  get password() {
    return this.formGroup.get('password');
  }
  get tipoUsuario() {
    return this.formGroup.get('tipoUsuario');
  }

}
