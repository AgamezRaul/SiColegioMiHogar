import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IEstudiante } from '../../estudiante/estudiante.component';
import { LoginService } from '../../login/login.service';
import { AlertService } from '../../notifications/_services';
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
    private activatedRoute: ActivatedRoute, private alertService: AlertService  ) { }

  responsables: IResponsable[] = [];
  responsable: IResponsable;
  prematricula: IPrematricula;
  prematricula1: IPrematricula;
  modoEdicion: boolean = false;
  prematriculaId: number;

  formGroupP = this.fb.group({
    ideResponsable: ['1998001', [Validators.required]],
    nomResponsable: ['', [Validators.required]],
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
    nomResponsable: ['', [Validators.required]],
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
    nomResponsable: ['', [Validators.required]],
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
    ideEstudiante: ['143614', [Validators.required]],
    nomEstudiante: ['Raul A', [Validators.required]],
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
      this.prematriculaId = parseInt(params["id"]);
      //console.log(this.prematriculaId);
      this.servicePrematricula.getPrematricula(this.prematriculaId)
        .subscribe(prematricula => this.cargarFormulario(prematricula),
          error => this.alertService.error(error.error)); 
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
    this.prematricula = { id: this.prematriculaId, idUsuario: idUsuario, responsables: this.responsables, estudiante: estudiante }
    if (this.modoEdicion) {
      //edita
      this.servicePrematricula.updatePreMatricula(this.prematricula)
        .subscribe(prematricula => this.onSaveSuccess(),
          error => this.alertService.error(error));
    } else {
      //crea
      this.servicePrematricula.createPrematricula(this.prematricula)
        .subscribe(prematricula => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
    }
  }

  cargarFormulario(prematricula: IPrematricula) {    
    this.formGroupE.patchValue({
      ideEstudiante: prematricula[0].estudiante[0].e['ideEstudiante'],
      nomEstudiante: prematricula[0].estudiante[0].e['nomEstudiante'],
      fecNacimiento: prematricula[0].estudiante[0].e['fecNacimiento'],
      lugNacimiento: prematricula[0].estudiante[0].e['lugNacimiento'],
      lugExpedicion: prematricula[0].estudiante[0].e['lugExpedicion'],
      insProcedencia: prematricula[0].estudiante[0].e['insProcedencia'],
      dirResidencia: prematricula[0].estudiante[0].e['dirResidencia'],
      celEstudiante: prematricula[0].estudiante[0].e['celEstudiante'],
      tipSangre: prematricula[0].estudiante[0].e['tipSangre'],
      gradoEstudiante: prematricula[0].estudiante[0].e['gradoEstudiante'],
      eps: prematricula[0].estudiante[0].e['eps'],
      correo: prematricula[0].estudiante[0].e['correo'],
      sexo: prematricula[0].estudiante[0].e['sexo'],
      tipoDocumento: prematricula[0].estudiante[0].e['tipoDocumento'],
      telEstudiante: prematricula[0].estudiante[0].e['telEstudiante']
    });
    prematricula[0].responsables.forEach(element => {      
      if (element.r.tipoResponsable == "Padre") {
        this.formGroupP.patchValue({
          ideResponsable: element.r.ideResponsable,
          nomResponsable: element.r.nomResponsable,
          fecNacimiento: element.r.fecNacimiento,
          lugNacimiento: element.r.lugNacimiento,
          lugExpedicion: element.r.lugExpedicion,
          tipDocumento: element.r.tipDocumento,
          celResponsable: element.r.celResponsable,
          profResponsable: element.r.profResponsable,
          ocuResponsable: element.r.ocuResponsable,
          entResponsable: element.r.entResponsable,
          celEmpresa: element.r.celEmpresa,
          tipoResponsable: element.r.tipoResponsable,
          correo: element.r.correo,
          acudiente: element.r.acudiente
        });
      } else if (element.r.tipoResponsable == "Madre") {
        this.formGroupM.patchValue({
          ideResponsable: element.r.ideResponsable,
          nomResponsable: element.r.nomResponsable,
          fecNacimiento: element.r.fecNacimiento,
          lugNacimiento: element.r.lugNacimiento,
          lugExpedicion: element.r.lugExpedicion,
          tipDocumento: element.r.tipDocumento,
          celResponsable: element.r.celResponsable,
          profResponsable: element.r.profResponsable,
          ocuResponsable: element.r.ocuResponsable,
          entResponsable: element.r.entResponsable,
          celEmpresa: element.r.celEmpresa,
          tipoResponsable: element.r.tipoResponsable,
          correo: element.r.correo,
          acudiente: element.r.acudiente
        });
      } else if (element.r.tipoResponsable == "Acudiente") {
        this.formGroupA.patchValue({
          ideResponsable: element.r.ideResponsable,
          nomResponsable: element.r.nomResponsable,
          fecNacimiento: element.r.fecNacimiento,
          lugNacimiento: element.r.lugNacimiento,
          lugExpedicion: element.r.lugExpedicion,
          tipDocumento: element.r.tipDocumento,
          celResponsable: element.r.celResponsable,
          profResponsable: element.r.profResponsable,
          ocuResponsable: element.r.ocuResponsable,
          entResponsable: element.r.entResponsable,
          celEmpresa: element.r.celEmpresa,
          tipoResponsable: element.r.tipoResponsable,
          correo: element.r.correo,
          acudiente: element.r.acudiente
        });
      }
    }); 
  }

  onSaveSuccess() {
    this.router.navigate(["/prematricula"]);
    this.alertService.success("Guardado exitoso");
  }
}

