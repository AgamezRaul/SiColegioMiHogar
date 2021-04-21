import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { AlertService } from '../../notifications/_services';
@Component({
  selector: 'app-form-mensualidad',
  templateUrl: './form-mensualidad.component.html',
  styleUrls: ['./form-mensualidad.component.css']
})
export class FormMensualidadComponent implements OnInit {


  constructor(private fb: FormBuilder, private mensualidadService: MensualidadService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private alertService: AlertService) { }
  modoEdicion: boolean = false;
  id: number;
  idMensu: number;

  formGroup = this.fb.group({
    mes: ['', [Validators.required, Validators.min(1), Validators.max(12)]],
    diaPago: ['', [Validators.required, Validators.min(1), Validators.max(31)]],
    fechaPago: ['', [Validators.required]],
    valorMensualidad:  ['', [Validators.required]],
    descuentoMensualidad: ['', [Validators.required]],
    abono: ['', [Validators.required]]
    
  });

  ngOnInit(): void {

    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-mensualidad') {
      this.modoEdicion = false;
      console.log("Registando");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
      });
    }
    else {
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idMensualidad"] == undefined) {
          return;
        }
        this.idMensu = parseInt(params["idMensualidad"]);
        this.mensualidadService.getMensualidad(this.idMensu)
          .subscribe(mensualidad => this.cargarFormulario(mensualidad),
            error => this.alertService.error(error.error));
        //validar cuando es repetida para avisarle al usuario
      });
    }
   
  }
  cargarFormulario(mensualiadad: IMensualidad) {
    this.formGroup.patchValue({
      mes: mensualiadad.mes,
      diaPago: mensualiadad.diaPago,
      fechaPago: mensualiadad.fechaPago,
      valorMensualidad: mensualiadad.valorMensualidad,
      descuentoMensualidad: mensualiadad.descuentoMensualidad,
      abono: mensualiadad.abono,
     
    });
  }
  save() {
    let mensualidad: IMensualidad = Object.assign({}, this.formGroup.value);
  

    if (this.modoEdicion) {//editar el registro
      mensualidad.id = this.idMensu;
      if (this.formGroup.valid) {
        this.mensualidadService.updateMensualidad(mensualidad)
          .subscribe(mensualidad => this.goBack(),
            error => this.alertService.error(error.error));
      } else { console.log('No valido') }
      
    }
    else {
    
      mensualidad.idMatricula = this.id;
      console.table(mensualidad); //ver mensualidad por consola
      if (this.formGroup.valid) {
        this.mensualidadService.createMensualidad(mensualidad)
          .subscribe(mensualidad => this.onSaveSuccess()),
          error => this.alertService.error(error);
      } else { console.log('No valido') }
         }
    

  }
 onSaveSuccess() {
   this.router.navigate(["/consultar-mensualidad/" + this.id]);
   this.alertService.success("Guardado exitoso");
  }
 
  goBack(): void{
    this.location.back();
  }

  get mes() {
    return this.formGroup.get('mes');
  }
  get diaPago() {
    return this.formGroup.get('diaPago');
  }
  get fechaPago() {
    return this.formGroup.get('fechaPago');
  }
  get valorMensualidad() {
    return this.formGroup.get('valorMensualidad');
  }
  get descuentoMensualidad() {
    return this.formGroup.get('descuentoMensualidad');
  }
  get abono() {
    return this.formGroup.get('abono');
  }
  
}


