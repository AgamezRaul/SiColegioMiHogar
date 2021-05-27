import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IEstudiante2 } from '../../../estudiante/estudiante.component';
import { EstudianteService } from '../../../estudiante/estudiante.service';
import { AlertService } from '../../../notifications/_services';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-form-usuario-estudiante',
  templateUrl: './form-usuario-estudiante.component.html',
  styleUrls: ['./form-usuario-estudiante.component.css']
})
export class FormUsuarioEstudianteComponent implements OnInit {
  ListaEstudiantes: IEstudiante2[] = [];

  constructor(private fb: FormBuilder, private usuarioService: UsuarioService, private estudianteService: EstudianteService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private location: Location) { }

  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]],
    tipoUsuario: ['Estudiante', [Validators.required]]
  });

  ngOnInit(): void {
    this.estudianteService.getEstudiantesUsuarios().subscribe(docente => this.LLenarDocentes(docente),
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
    this.alertService.success("Guardado exitoso");
  }
  LLenarDocentes(estudiantes: IEstudiante2[]) {
    this.ListaEstudiantes = estudiantes;
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

