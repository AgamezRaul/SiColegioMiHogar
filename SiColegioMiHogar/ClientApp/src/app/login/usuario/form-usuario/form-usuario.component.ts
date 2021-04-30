import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService  ) { }

  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]],
    tipoUsuario: ['Responsable', [Validators.required]]
  });

  ngOnInit(): void {
  }

  save() {
    let usuario: IUsuario = Object.assign({}, this.formGroup.value);
    console.table(usuario); //ver usuario por consola
    this.usuarioService.createUsuario(usuario)
      .subscribe(empleado => this.onSaveSuccess(),
        error => this.alertService.error(error.message));

  }
  onSaveSuccess() {
    this.router.navigate(["/login"]);
    this.alertService.success("Guardado exitoso");
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
