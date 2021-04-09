import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-gestion-de-materias',
  templateUrl: './gestion-de-materias.component.html',
  styleUrls: ['./gestion-de-materias.component.css']
})
export class GestionDeMateriasComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    IdMateria: ['', [Validators.required]],
    nomMateria: ['', [Validators.required]],
    NombreDocente: ['', [Validators.required]],
    NombreCurso: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }

  get IdMateria() {
    return this.formGroup.get('IdMateria');
  }
  get nomMateria() {
    return this.formGroup.get('nomMateria');
  }
  get NombreDocente() {
    return this.formGroup.get('NombreDocente');
  }
  get NombreCurso() {
    return this.formGroup.get('NombreCurso');
  }
}
