import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { LoginService } from '../../login/login.service';
import { IResponsable } from '../../responsable/responsable.component';
import { PreMatriculaService } from '../pre-matricula.service';

@Component({
  selector: 'app-form-pre-matricula',
  templateUrl: './form-pre-matricula.component.html',
  styleUrls: ['./form-pre-matricula.component.css']
})
export class FormPreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder, private serviceUser: LoginService,
    private servicePrematricula: PreMatriculaService, private router: Router) { }

  responsables: IResponsable[] = [];
  prematricula: IPrematricula;

  formGroupP = this.fb.group({
    ideResponsable: ['12345', [Validators.required]],
    nomResponsable: ['Raul', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Valledupar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['12312312', [Validators.required]],
    profResponsable: ['Valledupar', [Validators.required]],
    ocuResponsable: ['Valledupar', [Validators.required]],
    entResponsable: ['Valledupar', [Validators.required]],
    celEmpresa: ['12312323', [Validators.required]],
    tipoResponsable: ['Padre', [Validators.required]],
    correo: ['Valledupar@Valledupar', [Validators.required]],
    acudiente: ['', [Validators.required]]
  });
  formGroupM = this.fb.group({
    ideResponsable: ['67890', [Validators.required]],
    nomResponsable: ['Andres', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Valledupar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['12312312', [Validators.required]],
    profResponsable: ['Valledupar', [Validators.required]],
    ocuResponsable: ['Valledupar', [Validators.required]],
    entResponsable: ['Valledupar', [Validators.required]],
    celEmpresa: ['12312323', [Validators.required]],
    tipoResponsable: ['Madre', [Validators.required]],
    correo: ['Valledupar@Valledupar', [Validators.required]],
    acudiente: ['', [Validators.required]]
  });
  formGroupA = this.fb.group({
    ideResponsable: ['13579', [Validators.required]],
    nomResponsable: ['Agamez', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Valledupar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['12312312', [Validators.required]],
    profResponsable: ['Valledupar', [Validators.required]],
    ocuResponsable: ['Valledupar', [Validators.required]],
    entResponsable: ['Valledupar', [Validators.required]],
    celEmpresa: ['12312323', [Validators.required]],
    tipoResponsable: ['Acudiente', [Validators.required]],
    correo: ['Valledupar@Valledupar', [Validators.required]],
    acudiente: ['Si', [Validators.required]]
  });
  
  formGroupE = this.fb.group({
    ideEstudiante: ['12345678', [Validators.required]],
    nomEstudiante: ['Rapalino', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Valledupar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    insProcedencia: ['Valledupar', [Validators.required]],
    dirResidencia: ['Valledupar', [Validators.required]],
    celEstudiante: ['123123123', [Validators.required]],
    tipSangre: ['O+', [Validators.required]],
    gradoEstudiante: ['Primero', [Validators.required]],
    eps: ['Valledupar', [Validators.required]],
    correo: ['Valledupar@Valledupar', [Validators.required]],
    sexo: ['', [Validators.required]],
    tipoDocumento: ['', [Validators.required]],
    telEstudiante: ['12312323', [Validators.required]]
  });

  ngOnInit() {

  }

  save() {
    var idUsuario = this.serviceUser.getIdUser();
    let responsablePadre: IResponsable = Object.assign({}, this.formGroupP.value);
    let responsableMadre: IResponsable = Object.assign({}, this.formGroupM.value);
    let responsableAcudiente: IResponsable = Object.assign({}, this.formGroupA.value);
    responsablePadre.idUsuario = idUsuario;
    responsableMadre.idUsuario = idUsuario;
    responsableAcudiente.idUsuario = idUsuario;
    this.responsables.push(responsablePadre, responsableMadre, responsableAcudiente);
    let estudiante: IEstudiante = Object.assign({}, this.formGroupE.value);
    estudiante.idUsuario = idUsuario;
    this.prematricula = { idUsuario: idUsuario, responsables: this.responsables, estudiante: estudiante }

    console.log(this.prematricula);

    this.servicePrematricula.createPrematricula(this.prematricula)
      .subscribe(empleado => this.onSaveSuccess());
    
  }

  onSaveSuccess() {
    this.router.navigate(["/prematricula"]);
  }
}
export interface IPrematricula2 {
  idPrematricula: number,
  nomEstudiante: string,
  fecPrematricula: Date,
  estado: string,
}

export interface IPrematricula {
  idUsuario: number,
  responsables: IResponsable[],
  estudiante: IEstudiante
}
