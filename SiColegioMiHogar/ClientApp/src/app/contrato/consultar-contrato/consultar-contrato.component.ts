import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { IContrato} from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';
import { EstudianteService } from '../../estudiante/estudiante.service';
import { PeriodoService } from '../../periodo/periodo.service';
import { IEstudiante } from '../../estudiante/estudiante.component';

@Component({
  selector: 'app-consultar-contrato',
  templateUrl: './consultar-contrato.component.html',
  styleUrls: ['./consultar-contrato.component.css']
})
export class ConsultarContratoComponent implements OnInit {

  id: number;
  constructor(private fb: FormBuilder, private ContratoService: ContratoService, private router: Router, private activatedRoute: ActivatedRoute, private location: Location) { }

  formGroup = this.fb.group({
    fechaInicio: ['', [Validators.required]],
    fechaFin: ['', [Validators.required]],
    sueldo: ['', [Validators.required]],
    idDocente:  ['', [Validators.required]],
  });

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      params =>{
        if(params.has("id")){
          this.id = parseInt(params.get("id"));
          this.ContratoService.getContrato(this.id).subscribe(
            contrato => {
              this.cargarFormulario(contrato);
            },
          error => console.error(error));
        }
      }
    );
  }

  cargarFormulario(contrato: IContrato) {
    console.log(contrato);
    this.formGroup.patchValue({
      fechaInicio: contrato.fechaInicio,
      fechaFin: contrato.fechaFin,
      sueldo: contrato.sueldo,
      idDocente:  contrato.idDocente,
    });
  }

}
