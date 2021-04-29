import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { ICurso2 } from '../../curso/curso.component';
import { CursoService } from '../../curso/curso.service';
import { IDocente } from '../../docente/docente.component';
import { DocenteService } from '../../docente/docente.service';
import { AlertService } from '../../notifications/_services';
import { IMateria } from '../materia.component';
import { MateriaService } from '../materia.service';

@Component({
  selector: 'app-form-materia',
  templateUrl: './form-materia.component.html',
  styleUrls: ['./form-materia.component.css']
})
export class FormMateriaComponent implements OnInit {

  constructor(private fb: FormBuilder, private materiaservice: MateriaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private cursoservice: CursoService,
    private docenteService: DocenteService) { }

  modoEdicion: boolean = false;
  id: number;

  // cambios
  Listacurso: ICurso2[];
  Listadocente: IDocente[];


  formGroup = this.fb.group({
    nombreMateria: ['', [Validators.required]],
    idDocente: ['', [Validators.required]],
    idCurso: ['', [Validators.required]]
  });

  ngOnInit(): void {

    this.docenteService.getDocentes()
      .subscribe(docentes => this.llenarDocente(docentes),
      error => this.alertService.error(error.error));

    this.cursoservice.getCursos().
      subscribe(cursos => this.llenarCurso(cursos),
        error => this.alertService.error(error.error));

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;

      this.id = params["id"];

      this.materiaservice.getMateria(this.id)
        .subscribe(materia => this.cargarFormulario(materia)),
        error => this.alertService.error(error);
    });

  }


  cargarFormulario(materia: IMateria) {
    this.formGroup.patchValue({
      idMateria: materia.id,
      nombreMateria: materia.nombreMateria,
      idDocente: materia.idDocente,
      idCurso: materia.idCurso
    });
  }

  llenarDocente(docentes: IDocente[]) {
    this.Listadocente = docentes;
  }

  llenarCurso(cursos: ICurso2[]) {
    this.Listacurso = cursos;
  }

  save() {
    let materia: IMateria = Object.assign({}, this.formGroup.value);
    materia.idCurso = +materia.idCurso;
    materia.idDocente = +materia.idDocente;
    if (this.modoEdicion) {
      //editar registro
      materia.id = +this.id;
      this.materiaservice.updateMateria(materia)
        .subscribe(materia => this.onSaveSuccess()),
        error => this.alertService.error(error.error);
    } else {
      //agregar registro
      this.materiaservice.createMateria(materia)
        .subscribe(materia => this.onSaveSuccess()),
        error => this.alertService.error(error.error);
    }

  }

  onSaveSuccess() {
    this.router.navigate(["/materias"]);
    this.alertService.success("Guardado exitoso");
  }




  }
