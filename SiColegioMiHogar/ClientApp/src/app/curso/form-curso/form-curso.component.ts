import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { ICurso } from '../curso.component';
import { CursoService } from '../curso.service';
import { DocenteService } from 'src/app/docente/docente.service';
import { IDocente } from '../../Docente/docente.component';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-form-curso',
  templateUrl: './form-curso.component.html',
  styleUrls: ['./form-curso.component.css']
})
export class FormCursoComponent implements OnInit {

  ListaDocentes: IDocente[] = [];
  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private docenteService: DocenteService, private cursoService: CursoService, private alertService: AlertService) { }
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    maxEstudiantes: [10, [Validators.required]],
    idDirectorDocente: [4, [Validators.required]],
  });
  
  ngOnInit(): void {
    this.docenteService.getDocentes().subscribe(docentes => this.LlenarDocentes(docentes),
      error => this.alertService.error(error.error));
  }
  LlenarDocentes(docentes: IDocente[]) {
    this.ListaDocentes = docentes;
  }
  save() {
    let curso: ICurso = Object.assign({}, this.formGroup.value);
    
    console.table(curso); //ver mensualidad por consola
    curso.idDirectorDocente = +curso.idDirectorDocente;
    console.table(curso);
    this.cursoService.createCurso(curso)
      .subscribe(curso => this.onSaveSuccess(),
        error => this.alertService.error(error));
  }
  onSaveSuccess() {
    this.router.navigate(["/cursos"]);
    this.alertService.success("Guardado Exitoso");
  }

  get nombre() {
    return this.formGroup.get('nombre');
  }
  get maxEstudiantes() {
    return this.formGroup.get('maxEstudiantes');
  }
  get idDirectorDocente() {
    return this.formGroup.get('idDirectorDocente');
  }
}
