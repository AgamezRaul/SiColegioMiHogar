import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { DocenteService } from '../docente.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { IDocente } from '../docente.component';


@Component({
  selector: 'app-form-docente',
  templateUrl: './form-docente.component.html',
  styleUrls: ['./form-docente.component.css']
})
export class FormDocenteComponent implements OnInit {

  constructor(private fb: FormBuilder, private docenteService: DocenteService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private alertService: AlertService) { }
    modoEdicion: boolean = false;
    id: number;
    idDoc: number;

  formGroup = this.fb.group({
    nombreCompleto: ['Carlos', [Validators.required]],
    numTarjetaProf: ['1234567', [Validators.required]],
    cedula: ['7654321', [Validators.required]],
    celular: ['13579', [Validators.required]],
    correo: ['carlos@gmail.com', [Validators.required]],
    direccion: ['calle 30 #76-25', [Validators.required]],
  });
  ngOnInit(): void {
    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());
    if (segments[0].toString() == 'registrar-docente') {
      this.modoEdicion = false;
      console.log("Registando Docente");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
      });
    } else {
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idDocente"] == undefined) {
          return;
        }
        this.idDoc = parseInt(params["idDocente"]);
        this.docenteService.getDocente(this.idDoc)
          .subscribe(docente => this.cargarFormulario(docente),
            error => this.alertService.error(error.error));
        //validar cuando es repetida para avisarle al usuario
      });
    }

  }
  cargarFormulario(docente: IDocente) {
    this.formGroup.patchValue({
      nombreCompleto: docente.nombreCompleto,
      numTarjetaProf: docente.numTarjetaProf,
      cedula: docente.cedula,
      celular: docente.celular,
      direccion: docente.direccion,
      correo: docente.correo
    });
  }
  save() {
    let docente: IDocente = Object.assign({}, this.formGroup.value);
    if (this.modoEdicion) {//editar el regist
      docente.id = this.idDoc;
      if (this.formGroup.valid) {
        this.docenteService.updateDocente(docente)
          .subscribe(docente => this.onSaveSuccess(),
            error => this.alertService.error(error));
      } else { console.log('No valido') }
    } else {
      
      console.table(docente); //ver docente por consola
      if (this.formGroup.valid) {
        this.docenteService.createDocente(docente)
          .subscribe(docente => this.onSaveSuccess(),
            error => this.alertService.error(error));
      } else {
        console.log('No valido')
      }
    }
    
  }
  onSaveSuccess() {
    this.router.navigate(["/Docente"]);
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
