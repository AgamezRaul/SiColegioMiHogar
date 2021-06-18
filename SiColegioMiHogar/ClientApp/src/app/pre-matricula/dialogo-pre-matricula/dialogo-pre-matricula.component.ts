import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatriculaService } from '../../matricula/matricula.service';
import { MensajesModule } from '../../mensajes/mensajes.module';

@Component({
  selector: 'app-dialogo-pre-matricula',
  templateUrl: './dialogo-pre-matricula.component.html',
  styleUrls: ['./dialogo-pre-matricula.component.css']
})
export class DialogoPreMatriculaComponent implements OnInit {
  idPreMatricula: number;
  constructor(private fb: FormBuilder, private matriculaService: MatriculaService,
    private mensaje: MensajesModule, private dialogRef: MatDialogRef<DialogoPreMatriculaComponent>) { }
  formGroup = this.fb.group({
    valorMatricula: ['', [Validators.required]],
    idPrem: ['', [Validators.required]]
  });
  ngOnInit(): void {
    console.log(this.idPreMatricula);
  }

  get valorMatricula() {
    return this.formGroup.get('valorMatricula');
  }

  get idPrem() {
    return this.formGroup.get('idPrem');
  }
}
