import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurso } from '../curso.component';
import { CursoService } from '../curso.service';

@Component({
  selector: 'app-form-curso',
  templateUrl: './form-curso.component.html',
  styleUrls: ['./form-curso.component.css']
})
export class FormCursoComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute,
    private cursoService: CursoService) { }
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    maxEst: ['', [Validators.required]],
    idDirector: [1, [Validators.required]],
  });
  ngOnInit(): void {
  }
  save() {
    let curso: ICurso = Object.assign({}, this.formGroup.value);
    console.table(curso); //ver mensualidad por consola
    this.cursoService.createCurso(curso)
      .subscribe(curso => this.onSaveSuccess());
  }
  onSaveSuccess() {
    this.router.navigate(["/cursos"]);
  }

  get nombre() {
    return this.formGroup.get('nombre');
  }
  get maxEst() {
    return this.formGroup.get('maxEst');
  }
  get idDirector() {
    return this.formGroup.get('idDirector');
  }
}
