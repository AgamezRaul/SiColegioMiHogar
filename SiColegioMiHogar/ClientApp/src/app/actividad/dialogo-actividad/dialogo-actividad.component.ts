import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IActividad } from '../actividad.component';
import { ActividadService } from '../actividad.service';

@Component({
  selector: 'app-dialogo-actividad',
  templateUrl: './dialogo-actividad.component.html',
  styleUrls: ['./dialogo-actividad.component.css']
})
export class DialogoActividadComponent implements OnInit {

  constructor(private fb: FormBuilder, private actividadService: ActividadService,
    private mensaje: MensajesModule, private dialogRef: MatDialogRef<DialogoActividadComponent>) { }

  idPeriodo: number;
  idMateria: number;
  idActividad: number;

  formGroup = this.fb.group({
    descripcion: ['', [Validators.required]],
    porcentaje: ['', [Validators.required]]
  });

  ngOnInit(): void {
    if (this.idActividad != null) {
      this.actividadService.getActividad(this.idActividad).subscribe(actividad => this.cargarFormulario(actividad),
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
    }
  }

  cargarFormulario(actividad: IActividad) {
    this.formGroup.patchValue({
      descripcion: actividad.descripcion,
      porcentaje: actividad.porcentaje
    });
  }

  save() {
    let actividad: IActividad = Object.assign({}, this.formGroup.value);
    actividad.idMateria = this.idMateria;
    actividad.idPeriodo = this.idPeriodo;
    if (this.idActividad != null) {
      // edita
      actividad.id = this.idActividad;      
      this.actividadService.updateActividad(actividad)
        .subscribe(() => this.onSaveSuccessActualizar(),
          error => this.mensaje.mensajeAlertaError('Error', error.error.text.toString()));
      this.dialogRef.close();
    } else {
      // crea
      this.actividadService.createActividad(actividad)
        .subscribe(() => this.onSaveSuccessCrear(),
          error => this.mensaje.mensajeAlertaError('Error', error.error.text.toString()));
      this.dialogRef.close();
    }
  }

  onSaveSuccessCrear() {
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Actividad guardada correctamente');
  }

  onSaveSuccessActualizar() {
    this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Actividad actualizada correctamente');
  }

  get descripcion() {
    return this.formGroup.get('descripcion');
  }
  get porcentaje() {
    return this.formGroup.get('porcentaje');
  }

}
