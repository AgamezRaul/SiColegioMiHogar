import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../usuario.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { IUsuario2 } from '../usuario.component';
import { MensajesModule } from '../../../mensajes/mensajes.module';

@Component({
  selector: 'app-form-usuario-actualizar',
  templateUrl: './form-usuario-actualizar.component.html',
  styleUrls: ['./form-usuario-actualizar.component.css']
})
export class FormUsuarioActualizarComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private mensaje: MensajesModule) { }
    id: number;
    idUsuario: number;
  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    tipoUsuario: ['Responsable', [Validators.required]]
  });

  cargarFormulario(usuario: IUsuario2) {
    this.formGroup.patchValue({
      correo: usuario.correo,
      password: '123456',
      tipoUsuario: usuario.tipoUsuario
    });
  }


  ngOnInit(): void {
    console.log("editando")
    this.activatedRoute.params.subscribe(params => {

      if (params["idUsuario"] == undefined) {
        return;
      }
      this.idUsuario = parseInt(params["idUsuario"]);
      this.usuarioService.getUsuario2(this.idUsuario)
        .subscribe(usuario => this.cargarFormulario(usuario),
          error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));
      //validar cuando es repetida para avisarle al usuario
    });
  }
  save() {
    let usuario: IUsuario2 = Object.assign({}, this.formGroup.value);
    usuario.id = this.idUsuario;
    if (this.formGroup.valid) {
      this.usuarioService.updateUsuario2(usuario)
        .subscribe(docente => this.onSaveSuccess(),
          error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));
    } else {
      this.mensaje.mensajeAlertaError('¡Error!', 'No valido');
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/lista-usuario"]);
    this.mensaje.mensajeAlertaCorrecto('¡Exitoso!', 'Actualización exitosa');
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
