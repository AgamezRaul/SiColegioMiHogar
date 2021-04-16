import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { IMateria, IMateria2 } from '../gestion-de-materias.component';
import { GestionDeMateriasService } from '../gestion-de-materias.service';

@Component({
  selector: 'app-from-materia',
  templateUrl: './from-materia.component.html',
  styleUrls: ['./from-materia.component.css']
})
export class FromMateriaComponent implements OnInit {

  constructor(private fb: FormBuilder, private materiaservice: GestionDeMateriasService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  id: number;
  idmat: number;

  materia: IMateria

  formGroup = this.fb.group({
    IdMateria: ['', [Validators.required]],
    NombreMateria: ['', [Validators.required]],
    IdDocente: ['', [Validators.required]],
    IdCurso: ['', [Validators.required]]
  });

  ngOnInit(): void {

    //con esto se el url utilizo el primer semento para saber que url esta activa
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    console.log(segments[0].toString());

    if (segments[0].toString() == 'registrar-materia') {
      this.modoEdicion = false;
      console.log("Registando");
      this.activatedRoute.params.subscribe(params => {
        if (params["id"] == undefined) {
          return;
        }
        this.id = parseInt(params["id"]);
        console.log(this.id);

      });
    }
    else {
      this.modoEdicion = true;
      console.log("editando")
      this.activatedRoute.params.subscribe(params => {

        if (params["IdMateria"] == undefined) {
          return;
        }
        this.idmat = parseInt(params["IdMateria"]);
        console.log(this.idmat);

        this.materiaservice.getMateria(this.idmat)
          .subscribe(materia => this.cargarFormulario(materia),
            error => console.error(error));
      });
    }

  }

  cargarFormulario(materia: IMateria) {
    this.formGroup.patchValue({
      IdMateria: materia.IdMateria,
      NombreMateria: materia.NombreMateria,
      IdDocente: materia.IdDocente,
      IdCurso: materia.IdCurso
    });
  }

  save() {
    this.materia = Object.assign({}, this.formGroup.value);
    console.table(this.materia);

    this.materiaservice.createMateria(this.materia)
      .subscribe(materia => this.onSaveSuccess()),
      error => console.error(error);
  }

  onSaveSuccess() {
    this.router.navigate(["/materias"]);
  }
}
