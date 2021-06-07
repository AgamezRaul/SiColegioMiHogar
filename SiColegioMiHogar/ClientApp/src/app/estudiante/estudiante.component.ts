import { Component, OnInit } from '@angular/core';
import { IUsuario } from '../login/usuario/usuario.component';
import { UsuarioService } from '../login/usuario/usuario.service';
import { IMateria } from '../materia/materia.component';
import { MateriaService } from '../materia/materia.service';
import { MensajesModule } from '../mensajes/mensajes.module';
import { EstudianteService } from './estudiante.service';

@Component({
  selector: 'app-estudiante',
  templateUrl: './estudiante.component.html',
  styleUrls: ['./estudiante.component.css']
})
export class EstudianteComponent implements OnInit {
  idUsuario: number;
  usuario: IUsuario;
  materiasEstudiante: IMateria[];
  constructor(private materiaService: MateriaService, private mensaje: MensajesModule,
    private usuarioService: UsuarioService, private estudianteService: EstudianteService) { }

  ngOnInit() {
    const usuario = JSON.parse(localStorage.getItem('user'));
    this.idUsuario = usuario["id"];
    this.usuarioService.getUsuarioId(this.idUsuario).subscribe(user =>
      this.estudianteService.getUsuarioEstudiante(user.correo).subscribe(estudiante =>
        this.materiaService.GetMateriasEstudiante(estudiante.id).subscribe(materias =>
          this.materiasEstudiante = materias)));
  }

}

export interface IEstudiante2 {
  id: number,
  ideEstudiante: string,
  nomEstudiante: string,
  correo: string,
  idUsuario: number
}

export interface IEstudiante {
  id: number,
  ideEstudiante: string,
  nomEstudiante: string,
  fecNacimiento: Date,
  lugNacimiento: string,
  lugExpedicion: string,
  insProcedencia: string,
  dirResidencia: string,
  celEstudiante: string,
  tipSangre: string,
  gradoEstudiante: string,
  eps: string,
  correo: string,
  sexo: string,
  tipoDocumento: string,
  telEstudiante: string,
  idUsuario: number
}
