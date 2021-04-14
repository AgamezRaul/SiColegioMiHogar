import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';

@Component({
  selector: 'app-form-mensualidad',
  templateUrl: './form-mensualidad.component.html',
  styleUrls: ['./form-mensualidad.component.css']
})
export class FormMensualidadComponent implements OnInit {


  constructor(private fb: FormBuilder, private mensualidadService: MensualidadService,
    private router: Router, private activatedRoute: ActivatedRoute) { }
  modoEdicion: boolean = false;
  id: number;
  idMensu: number;

  formGroup = this.fb.group({
    mes: ['', [Validators.required]],
    diaPago: ['', [Validators.required]],
    fechaPago: ['', [Validators.required]],
    valorMensualidad:  ['', [Validators.required]],
    descuentoMensualidad: ['', [Validators.required]],
    abono: ['', [Validators.required]],
    estado: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      if (params["idMensualidad"] == undefined) {
        return;
      }


      this.id = parseInt(params["id"]);
      console.log(this.id);
      //falta el condicional para saber si viene de matricula o viene de mensualidad edicion
      if (this.idMensu != undefined) { this.modoEdicion = true; }
      
     

      this.idMensu = parseInt(params["idMensualidad"]);
      console.log(this.idMensu);
      this.mensualidadService.getMensualidad(this.idMensu)
        .subscribe(mensualidad => this.cargarFormulario(mensualidad),
          error => console.error(error));
    });
  
  }
  cargarFormulario(mensualiadad: IMensualidad) {
    this.formGroup.patchValue({
      mes: mensualiadad.mes,
      diaPago: mensualiadad.diaPago,
      fechaPago: mensualiadad.fechaPago,
      valorMensualidad: mensualiadad.valorMensualidad,
      descuentoMensualidad: mensualiadad.descuentoMensualidad,
      abono: mensualiadad.abono,
      estado: mensualiadad.estado
    });
  }
  save() {
    let mensualidad: IMensualidad = Object.assign({}, this.formGroup.value);
  

    if (this.modoEdicion) {//editar el registro
      mensualidad.id = this.idMensu;
      this.mensualidadService.updateMensualidad(mensualidad)
        .subscribe(mensualidad => this.onSaveSuccess(),
          error => console.error(error));
    }
    else {
    
      mensualidad.idMatricula = this.id;
      console.table(mensualidad); //ver mensualidad por consola
      this.mensualidadService.createMensualidad(mensualidad)
        .subscribe(mensualidad => this.onSaveSuccess());

    }
    

  }
 onSaveSuccess() {
   this.router.navigate(["/consultar-mensualidad/"+this.id]);
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
  get estado() {
    return this.formGroup.get('estado');
  }
}


