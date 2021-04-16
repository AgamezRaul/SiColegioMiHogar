import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { IMateria } from '../gestion-de-materias.component';
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
    idMateria: ['', [Validators.required]],
    nombreMateria: ['', [Validators.required]],
    idDocente: ['', [Validators.required]],
    idCurso: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }

  save() {
    let materia: IMateria = Object.assign({}, this.formGroup.value);
    console.table(this.materia);
    this.materiaservice.createMateria(materia)
      .subscribe(materia => this.onSaveSuccess()),
      error => console.error(error);
  }

  onSaveSuccess() {
    this.router.navigate(["/materias"]);
  }
}
