import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IDocente } from '../../../docente/docente.component';
import { DocenteService } from '../../../docente/docente.service';
import { AlertService } from '../../../notifications/_services';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-form-usuario-docente',
  templateUrl: './form-usuario-docente.component.html',
  styleUrls: ['./form-usuario-docente.component.css']
})
export class FormUsuarioDocenteComponent implements OnInit {
  ListaDocentes: IDocente[] = [];

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService, private docenteService: DocenteService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private location: Location) { }
  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]],
    tipoUsuario: ['Docente', [Validators.required]]
  });

  ngOnInit(): void {
    this.docenteService.getDocenteUsuarios().subscribe(docente => this.LLenarDocentes(docente),
      error => this.alertService.error(error));
   
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
    this.alertService.success("Usuario docente registrado correctamente");
  }
  LLenarDocentes(docentes: IDocente[]) {
    this.ListaDocentes = docentes;
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
