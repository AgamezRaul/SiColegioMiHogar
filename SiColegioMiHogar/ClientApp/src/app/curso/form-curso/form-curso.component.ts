import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { ICurso } from '../curso.component';
import { CursoService } from '../curso.service';
import { DocenteService } from 'src/app/docente/docente.service';
import { IDocente } from '../../Docente/docente.component';
import { MatTableDataSource } from '@angular/material/table';
import { UrlSegment } from '@angular/router';

@Component({
  selector: 'app-form-curso',
  templateUrl: './form-curso.component.html',
  styleUrls: ['./form-curso.component.css']
})
export class FormCursoComponent implements OnInit {

  ListaDocentes: IDocente[] = [];
  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private docenteService: DocenteService, private cursoService: CursoService, private alertService: AlertService) { }
  modoEdicion: boolean = false;
  id: number;
  idCurso: number;
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    maxEstudiantes: [10, [Validators.required]],
    idDirectorDocente: [4, [Validators.required]],
    letra: ['', [Validators.required]]
  });
  
  ngOnInit(): void {

    this.docenteService.getDocentes().subscribe(docentes => this.LlenarDocentes(docentes),
      error => this.alertService.error(error.error));
    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    if (segments[0].toString() == 'registrar-curso') {
      this.modoEdicion = false;
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

        if (params["idCurso"] == undefined) {
          return;
        }
        this.idCurso = parseInt(params["idCurso"]);
        this.cursoService.getCurso(this.idCurso)
          .subscribe(curso => this.cargarFormulario(curso),
            error => this.alertService.error(error.error));
        //validar cuando es repetida para avisarle al usuario
      });
    }
  }
  cargarFormulario(curso: ICurso) {
    this.formGroup.patchValue({
      nombre: curso.nombre,
      maxEstudiantes: curso.maxEstudiantes,
      idDirectorDocente: curso.idDirectorDocente,
      letra: curso.letra
    });
  }
  LlenarDocentes(docentes: IDocente[]) {
    this.ListaDocentes = docentes;
  }
  save() {
    let curso: ICurso = Object.assign({}, this.formGroup.value);
    console.table(curso);
    curso.idDirectorDocente = +curso.idDirectorDocente;
    console.table(curso);
    if (this.modoEdicion) {//editar el regist
      curso.id = this.idCurso;
      if (this.formGroup.valid) {
        this.cursoService.updateCurso(curso)
          .subscribe(() => this.onSaveSuccess(),
            error => console.log(error));
      } else { console.log('No valido') }
    } else {

      console.table(curso); //ver curso por consola
      if (this.formGroup.valid) {
        this.cursoService.createCurso(curso)
          .subscribe(() => this.onSaveSuccess(),
            error => console.log(error));
      } else {
        console.log('No valido')
      }
    }
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
  get letra() {
    return this.formGroup.get('letra');
  }
}
