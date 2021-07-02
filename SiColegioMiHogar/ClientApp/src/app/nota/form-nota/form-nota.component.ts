import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { INota, INotaConsult } from '../nota.component';
import { NotaService } from '../nota.service';
import { EstudianteService } from '../../estudiante/estudiante.service';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { AlertService } from '../../notifications/_services';
import { MensajesModule } from '../../mensajes/mensajes.module';


@Component({
  selector: 'app-form-nota',
  templateUrl: './form-nota.component.html',
  styleUrls: ['./form-nota.component.css']
})
export class FormNotaComponent implements OnInit {

  constructor(private fb: FormBuilder, private notaservice: NotaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private estudianteService: EstudianteService, private mensaje: MensajesModule,
    private alertService: AlertService) { }

  modoEdicion: boolean = false;
  idActividad: number;
  idNota: number;
  idMateria: number;
  estudiantes: IEstudiante[];
  notas: INota[];
  notasEstudiantesFormGroup;

  formGroup = this.fb.group({
    notasEstudiantes: this.fb.array([])
  });

  ngOnInit(): void {

    this.activatedRoute.params.subscribe(params => {
      if (params["idMateria"] != undefined) {
        this.idMateria = parseInt(params["idMateria"]);
        this.idActividad = parseInt(params["idActividad"]);
        this.estudianteService.GetEstudianteCurso(this.idMateria).subscribe(
          estudiantes => {
            this.estudiantes = estudiantes;
            this.estudiantes.forEach(estudiante => {
              this.notasEstudiantesFormGroup = this.fb.group({
                notaAlumno: [0, [Validators.required, Validators.min(1), Validators.max(100)]],
                nomEstudiante: [estudiante.nomEstudiante],
                idEstudiante: [estudiante.id],
                idActividad: [this.idActividad]
              });
              this.notasEstudiantes.push(this.notasEstudiantesFormGroup);
            });
          }
        );
      } else{
        this.modoEdicion = true;
        this.idActividad = params["idActividad"];
      }
    });
  }

  cargarFormulario(nota: INotaConsult) {
    console.table(nota);
  }

  save() {
    let notasEstudiantes = Object.assign({}, this.formGroup.value);
    this.notas = notasEstudiantes['notasEstudiantes'];
    if (this.modoEdicion) {

    } else {
      this.notaservice.createNota(this.notas)
        .subscribe(() => this.onSaveSuccess(),
          error => console.log(error));//this.mensaje.mensajeAlertaError('Error', error.error.message));
    } 
  }
  
  onSaveSuccess() {
    this.router.navigate(["listar-notas"]);
    this.alertService.success("Registro de nota exitoso");
  }

  get notasEstudiantes() {
    return this.formGroup.get('notasEstudiantes') as FormArray;
  }
  get notaAlumno() {
    return this.notasEstudiantesFormGroup.get('notaAlumno');
  }
  get nomEstudiante() {
    return this.notasEstudiantesFormGroup.get('nomEstudiante');
  }
  get IdEstudiante() {
    return this.notasEstudiantesFormGroup.get('IdEstudiante');
  }
  get IdActividad() {
    return this.notasEstudiantesFormGroup.get('IdActividad');
  }
}
