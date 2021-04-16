import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UrlSegment } from '@angular/router';
import { ActivatedRoute, Router } from '@angular/router';
import { INota, INotaConsult,IEstudianteNota, IPeriodoNota, MateriaNota } from '../nota.component';
import { NotaService } from '../nota.service';
import { Location } from '@angular/common';
import { error } from 'protractor';
import { equal } from 'assert';

@Component({
  selector: 'app-form-nota',
  templateUrl: './form-nota.component.html',
  styleUrls: ['./form-nota.component.css']
})
export class FormNotaComponent implements OnInit {

  ListaEstudiantes: IEstudianteNota[] = [];
  ListaPeriodos: IPeriodoNota[] = [];
  ListaMaterias: MateriaNota[] = [];

  constructor(private fb: FormBuilder, private notaservice: NotaService,private router: Router, private activatedRoute: ActivatedRoute, private location: Location) { }
  modoEdicion: boolean = false;
  id: number;
  idNota: number;

  formGroup = this.fb.group({
    Descripcion: ['', [Validators.required]],
    NotaAlumno: ['', [Validators.required]],
    IdEstudiante: ['', [Validators.required]],
    IdMateria:  ['', [Validators.required]],
    IdPeriodo:  ['', [Validators.required]],
  });

  ngOnInit(): void {
    
    
    this.notaservice.getEstudiantes().subscribe(estudiantes => this.LLenarEstudiantes(estudiantes),error => console.error(error));

    this.notaservice.getPeriodos().subscribe(periodos => this.LLenarPeriodos(periodos),error => console.error(error));

    this.notaservice.getMaterias().subscribe(materias => this.LLenarMaterias(materias),error => console.error(error));

    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-nota') {
      this.modoEdicion = false;
      console.log("Registando");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
        console.log(this.id);

      });
    }else{
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["idNota"] == undefined) {
          return;
        }
        this.idNota = parseInt(params["idNota"]);
        console.log(this.idNota);

        this.notaservice.getNota(this.idNota)
          .subscribe(periodo => this.cargarFormulario(periodo),
            error => console.error(error));
        //validar cuando es repetida para avisarle al usuario
      });
    }  
  }

  LLenarEstudiantes(estudantes: IEstudianteNota[]){
    this.ListaEstudiantes = estudantes;
  }

  LLenarPeriodos(periodos: IPeriodoNota[]){
    this.ListaPeriodos = periodos;
  }

  LLenarMaterias(materias: MateriaNota[]){
    this.ListaMaterias = materias;
  }

  cargarFormulario(nota: INotaConsult) {
    this.formGroup.patchValue({
      Descripcion:  nota.descripcion,
      NotaAlumno: nota.notaAlumno,
      IdEstudiante: nota.estudiante,
      IdMateria:  nota.materia,
      IdPeriodo:  nota.periodo,
    });
  }

  save(){
    let nota: INota = Object.assign({}, this.formGroup.value);
    if (this.formGroup.valid) {
      this.notaservice.createNota(nota)
        .subscribe(response => this.onSaveSuccess()),
        error => console.error(error);
    }else{ 
      console.log('No valido') 
    }
  }

  
  onSaveSuccess() {
    this.router.navigate(["listar-notas"]);
  }

  get IdPeriodo() {
    return this.formGroup.get('IdPeriodo');
  }

  get IdMateria() {
    return this.formGroup.get('IdMateria');
  }

  get IdEstudiante() {
    return this.formGroup.get('IdEstudiante');
  }

  get NotaAlumno() {
    return this.formGroup.get('NotaAlumno');
  }

  get Descripcion() {
    return this.formGroup.get('Descripcion');
  }
}
