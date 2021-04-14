import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { LoginService } from '../../login/login.service';
import { IResponsable } from '../../responsable/responsable.component';
import { IPrematricula } from '../pre-matricula.component';
import { PreMatriculaService } from '../pre-matricula.service';

@Component({
  selector: 'app-form-pre-matricula',
  templateUrl: './form-pre-matricula.component.html',
  styleUrls: ['./form-pre-matricula.component.css']
})
export class FormPreMatriculaComponent implements OnInit {

  constructor(private fb: FormBuilder, private serviceUser: LoginService,
    private servicePrematricula: PreMatriculaService, private router: Router,
    private activatedRoute: ActivatedRoute  ) { }

  responsables: IResponsable[] = [];
  responsable: IResponsable;
  prematricula: IPrematricula;
  modoEdicion: boolean = false;
  prematriculaId: number;

  formGroupP = this.fb.group({
    ideResponsable: ['1998001', [Validators.required]],
    nomResponsable: ['Luis', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Cesar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['123456789', [Validators.required]],
    profResponsable: ['Docente', [Validators.required]],
    ocuResponsable: ['Docente', [Validators.required]],
    entResponsable: ['Desconocido', [Validators.required]],
    celEmpresa: ['Desconocido', [Validators.required]],
    tipoResponsable: ['Padre', [Validators.required]],
    correo: ['luis@gmail.com', [Validators.required]],
    acudiente: ['', [Validators.required]]
  });
  formGroupM = this.fb.group({
    ideResponsable: ['1998002', [Validators.required]],
    nomResponsable: ['Camila', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Cesar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['123456789', [Validators.required]],
    profResponsable: ['Docente', [Validators.required]],
    ocuResponsable: ['Docente', [Validators.required]],
    entResponsable: ['Desconocido', [Validators.required]],
    celEmpresa: ['Desconocido', [Validators.required]],
    tipoResponsable: ['Madre', [Validators.required]],
    correo: ['camila@gmail.com', [Validators.required]],
    acudiente: ['', [Validators.required]]
  });
  formGroupA = this.fb.group({
    ideResponsable: ['1998003', [Validators.required]],
    nomResponsable: ['Camilo', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Cesar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    tipDocumento: ['', [Validators.required]],
    celResponsable: ['123456789', [Validators.required]],
    profResponsable: ['Docente', [Validators.required]],
    ocuResponsable: ['Docente', [Validators.required]],
    entResponsable: ['Desconocido', [Validators.required]],
    celEmpresa: ['Desconocido', [Validators.required]],
    tipoResponsable: ['Acudiente', [Validators.required]],
    correo: ['camilo@gmail.com', [Validators.required]],
    acudiente: ['Si', [Validators.required]]
  });
  
  formGroupE = this.fb.group({
    ideEstudiante: ['109283097', [Validators.required]],
    nomEstudiante: ['Raul Agamez', [Validators.required]],
    fecNacimiento: ['', [Validators.required]],
    lugNacimiento: ['Valledupar', [Validators.required]],
    lugExpedicion: ['Valledupar', [Validators.required]],
    insProcedencia: ['Desconocido', [Validators.required]],
    dirResidencia: ['Desconocido', [Validators.required]],
    celEstudiante: ['Desconocido', [Validators.required]],
    tipSangre: ['Desconocido', [Validators.required]],
    gradoEstudiante: ['1', [Validators.required]],
    eps: ['Desconocido', [Validators.required]],
    correo: ['raulagamez@gmail.com', [Validators.required]],
    sexo: ['', [Validators.required]],
    tipoDocumento: ['', [Validators.required]],
    telEstudiante: ['Desconocido', [Validators.required]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.modoEdicion = true;
      this.prematriculaId = params["id"];
      console.log(this.prematriculaId);
      this.servicePrematricula.getPrematricula(this.prematriculaId)
        .subscribe(prematricula => console.log(prematricula.idPrematricula)/*this.cargarFormulario(prematricula)*/,
        error => error(error.message)); 
    });
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
    this.prematricula = { idPrematricula: this.prematriculaId, idUsuario: idUsuario, responsables: this.responsables, estudiante: estudiante }
    if (this.modoEdicion) {
      //edita
      this.servicePrematricula.updatePreMatricula(this.prematricula)
        .subscribe(prematricula => this.onSaveSuccess());
    } else {
      //crea
      
      console.log(this.prematricula);
      this.servicePrematricula.createPrematricula(this.prematricula)
        .subscribe(prematricula => this.onSaveSuccess());
    }
  }

  cargarFormulario(prematricula: IPrematricula) {
    this.formGroupE.patchValue({
      ideEstudiante: prematricula.estudiante.ideEstudiante,
      nomEstudiante: prematricula.estudiante.nomEstudiante,
      fecNacimiento: prematricula.estudiante.fecNacimiento,
      lugNacimiento: prematricula.estudiante.lugNacimiento,
      lugExpedicion: prematricula.estudiante.lugExpedicion,
      insProcedencia: prematricula.estudiante.insProcedencia,
      dirResidencia: prematricula.estudiante.dirResidencia,
      celEstudiante: prematricula.estudiante.celEstudiante,
      tipSangre: prematricula.estudiante.tipSangre,
      gradoEstudiante: prematricula.estudiante.gradoEstudiante,
      eps: prematricula.estudiante.eps,
      correo: prematricula.estudiante.correo,
      sexo: prematricula.estudiante.sexo,
      tipoDocumento: prematricula.estudiante.tipoDocumento,
      telEstudiante: prematricula.estudiante.telEstudiante
    });
    prematricula.responsables.forEach(element => {
      if (element.tipoResponsable == "Padre") {
        this.formGroupP.patchValue({
          ideResponsable: element.ideResponsable,
          nomResponsable: element.nomResponsable,
          fecNacimiento: element.fecNacimiento,
          lugNacimiento: element.lugNacimiento,
          lugExpedicion: element.lugExpedicion,
          tipDocumento: element.tipDocumento,
          celResponsable: element.celResponsable,
          profResponsable: element.profResponsable,
          ocuResponsable: element.ocuResponsable,
          entResponsable: element.entResponsable,
          celEmpresa: element.celEmpresa,
          tipoResponsable: element.tipoResponsable,
          correo: element.correo,
          acudiente: element.acudiente
        });
      } else if (element.tipoResponsable == "Madre") {
        this.formGroupM.patchValue({
          ideResponsable: element.ideResponsable,
          nomResponsable: element.nomResponsable,
          fecNacimiento: element.fecNacimiento,
          lugNacimiento: element.lugNacimiento,
          lugExpedicion: element.lugExpedicion,
          tipDocumento: element.tipDocumento,
          celResponsable: element.celResponsable,
          profResponsable: element.profResponsable,
          ocuResponsable: element.ocuResponsable,
          entResponsable: element.entResponsable,
          celEmpresa: element.celEmpresa,
          tipoResponsable: element.tipoResponsable,
          correo: element.correo,
          acudiente: element.acudiente
        });
      } else if (element.tipoResponsable == "Acudiente") {
        this.formGroupA.patchValue({
          ideResponsable: element.ideResponsable,
          nomResponsable: element.nomResponsable,
          fecNacimiento: element.fecNacimiento,
          lugNacimiento: element.lugNacimiento,
          lugExpedicion: element.lugExpedicion,
          tipDocumento: element.tipDocumento,
          celResponsable: element.celResponsable,
          profResponsable: element.profResponsable,
          ocuResponsable: element.ocuResponsable,
          entResponsable: element.entResponsable,
          celEmpresa: element.celEmpresa,
          tipoResponsable: element.tipoResponsable,
          correo: element.correo,
          acudiente: element.acudiente
        });
      }
    }); 
  }

  onSaveSuccess() {
    this.router.navigate(["/prematricula"]);
  }
}

