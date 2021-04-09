import { Component, Input, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IEstudiante } from '../estudiante/estudiante.component';
import { IResponsable } from '../responsable/responsable.component';

@Component({
  selector: 'app-pre-matricula',
  templateUrl: './pre-matricula.component.html',
  styleUrls: ['./pre-matricula.component.css']
})
export class PreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  ngOnInit() {

  }
}
