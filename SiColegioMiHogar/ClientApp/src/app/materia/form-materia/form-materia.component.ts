import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
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
    private alertService: AlertService  ) { }

  modoEdicion: boolean = false;
  id: number;

  formGroup = this.fb.group({
    idMateria: ['', [Validators.required]],
    nombreMateria: ['', [Validators.required]],
    idDocente: ['', [Validators.required]],
    idCurso: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;

      this.id = params["id"];

      this.materiaservice.getMateria(this.id)
        .subscribe(materia => this.cargarFormulario(materia)),
        error => this.alertService.error(error.error);
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


  save() {
    let materia: IMateria = Object.assign({}, this.formGroup.value);

    if (this.modoEdicion) {
      //editar registro
      materia.id = this.id;
      this.materiaservice.updateMateria(materia)
        .subscribe(materia => this.onSaveSuccess()),
        error => this.alertService.error(error.error);

      console.table(materia);

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
