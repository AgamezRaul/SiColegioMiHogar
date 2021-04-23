import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IDocente } from '../docente.component';
import { DocenteService } from '../docente.service';

@Component({
  selector: 'app-form-docente',
  templateUrl: './form-docente.component.html',
  styleUrls: ['./form-docente.component.css']
})
export class FormDocenteComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private docenteService: DocenteService, private alertService: AlertService) { }
  formGroup = this.fb.group({
    nombreCompleto: ['', [Validators.required]],
    numTarjetaProf: ['', [Validators.required]],
    cedula: ['', [Validators.required]],
    celular: ['', [Validators.required]],
    correo: ['', [Validators.required]],
    direccion: ['', [Validators.required]],
  });
  ngOnInit(): void {
  }
  save() {
    let docente: IDocente = Object.assign({}, this.formGroup.value);
    console.table(docente); //ver docente por consola
    this.docenteService.createDocente(docente)
      .subscribe(docente => this.onSaveSuccess(),
        error => this.alertService.error(error));
  }
  onSaveSuccess() {
    this.router.navigate(["/Docente"]);
    this.router.navigate(["/"]);
    this.alertService.success("Guardado exitoso");
  }

  get nombreCompleto() {
    return this.formGroup.get('nombreCompleto');
  }
  get numTarjetaProf() {
    return this.formGroup.get('numTarjetaProf');
  }
  get cedula() {
    return this.formGroup.get('cedula');
  }
  get celular() {
    return this.formGroup.get('celular');
  }
  get correo() {
    return this.formGroup.get('correo');
  }
  get direccion() {
    return this.formGroup.get('direccion');
  }
  

}
