import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { IMateria } from '../materia.component';
import { MateriaService } from '../materia.service';

@Component({
  selector: 'app-form-materia',
  templateUrl: './form-materia.component.html',
  styleUrls: ['./form-materia.component.css']
})
export class FormMateriaComponent implements OnInit {

  constructor(private fb: FormBuilder, private materiaservice: MateriaService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  id: number;

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
    this.materiaservice.createMateria(materia)
      .subscribe(materia => this.onSaveSuccess()),
      error => console.error(error);
  }

  onSaveSuccess() {
    this.router.navigate(["/materias"]);
  }
}
