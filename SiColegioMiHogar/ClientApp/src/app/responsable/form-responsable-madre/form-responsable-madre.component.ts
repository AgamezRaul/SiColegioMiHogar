import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-responsable-madre',
  templateUrl: './form-responsable-madre.component.html',
  styleUrls: ['./form-responsable-madre.component.css']
})
export class FormResponsableMadreComponent implements OnInit {

  @Input() formGroupM: FormGroup;

  /*formGroupM = this.fb.group({
    ideResponsableMadre: ['', [Validators.required]],
    nomResponsableMadre: ['', [Validators.required]],
    fechaNacimientoMadre: ['', [Validators.required]],
    lugNacimientoMadre: ['', [Validators.required]],
    lugExpedicionMadre: ['', [Validators.required]],
    tipDocumentoMadre: ['', [Validators.required]],
    celResponsableMadre: ['', [Validators.required]],
    profResponsableMadre: ['', [Validators.required]],
    ocuResponsableMadre: ['', [Validators.required]],
    entResponsableMadre: ['', [Validators.required]],
    celEmpresaMadre: ['', [Validators.required]],
    tipoResponsableMadre: ['', [Validators.required]],
    correoMadre: ['', [Validators.required]],
    acudienteMadre: ['', [Validators.required]]
  });*/

  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  

  ngOnInit() {
  }
  get ideResponsableMadre() {
    return this.formGroupM.get('ideResponsableMadre');
  }
  get nomResponsableMadre() {
    return this.formGroupM.get('nomResponsableMadre');
  }
  get fechaNacimientoMadre() {
    return this.formGroupM.get('fechaNacimientoMadre');
  }
  get lugNacimientoMadre() {
    return this.formGroupM.get('lugNacimientoMadre');
  }
  get tipDocumentoMadre() {
    return this.formGroupM.get('tipDocumentoMadre');
  }
  get celResponsableMadre() {
    return this.formGroupM.get('celResponsableMadre');
  }
  get profResponsableMadre() {
    return this.formGroupM.get('profResponsableMadre');
  }
  get ocuResponsableMadre() {
    return this.formGroupM.get('ocuResponsableMadre');
  }
  get entResponsableMadre() {
    return this.formGroupM.get('entResponsableMadre');
  }
  get celEmpresaMadre() {
    return this.formGroupM.get('celEmpresaMadre');
  }
  get tipoResponsableMadre() {
    return this.formGroupM.get('tipoResponsableMadre');
  }
  get correoMadre() {
    return this.formGroupM.get('correoMadre');
  }
  get acudienteMadre() {
    return this.formGroupM.get('acudienteMadre');
  }
  
}
