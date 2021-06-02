import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurso } from '../../curso/curso.component';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IEstudianteCurso } from '../estudiante-curso.component';
import { EstudianteCursoService } from '../estudiante-curso.service';

@Component({
  selector: 'app-form-estudiante-curso',
  templateUrl: './form-estudiante-curso.component.html',
  styleUrls: ['./form-estudiante-curso.component.css']
})
export class FormEstudianteCursoComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute, private mensaje: MensajesModule,
    private estudianteCursoService: EstudianteCursoService) { }
  estudiantes: IEstudiante[];
  cursos: ICurso[];
  estudiantesCursos: IEstudianteCurso[];
  estudiantesCursos2: IEstudianteCurso[];
  EstudianteCursoFormGroup;
  modoEdicion: boolean = false;
  id: number;
  formGroup = this.fb.group({
    curso: [[Validators.required]],
    estudiantesCurso: this.fb.array([])    
  });
  ngOnInit(): void {}

  changedGrado(grado: string) {
    this.estudianteCursoService.getCursoGrado(grado).subscribe(cursos => {
      this.cursos = cursos;
      this.estudianteCursoService.getEstudianteGrado(grado).subscribe(estudiantes => {
        this.estudiantes = estudiantes;

        this.estudiantes.forEach(estudiante => {

          this.EstudianteCursoFormGroup = this.fb.group({
            Estudiante: [estudiante.nomEstudiante],
            idEstudiante: [estudiante.id],
            idCurso: [[Validators.required]]
          });
          this.estudiantesCurso.push(this.EstudianteCursoFormGroup);
        });
      });
    });
  }

  save() {
    let estudiantesCurso = Object.assign({}, this.formGroup.value);
    this.estudiantesCursos2 = estudiantesCurso['estudiantesCurso'];   

    if (this.modoEdicion) {
        
    } else {
      this.estudianteCursoService.createEstudianteCurso(this.estudiantesCursos2)
        .subscribe(() => this.onSaveSuccess(),
          error => console.log(error));//this.mensaje.mensajeAlertaError('Error', error.error.message));
    }    
  }

  onSaveSuccess() {
    this.router.navigate(["/estudiante-curso"]);
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Se asignaron los estudiantes');
  }
  get curso() {
    return this.formGroup.get('curso');
  }
  get estudiantesCurso() {
    return this.formGroup.get('estudiantesCurso') as FormArray;
  }
  get idEstudiante() {
    return this.EstudianteCursoFormGroup.get('idEstudiante');
  }
  get idCurso() {
    return this.EstudianteCursoFormGroup.get('idCurso');
  }
}
