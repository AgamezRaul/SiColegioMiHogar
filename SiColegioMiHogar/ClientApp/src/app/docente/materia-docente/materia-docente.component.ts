import { Component, OnInit } from '@angular/core';
import { IUsuario } from '../../login/usuario/usuario.component';
import { UsuarioService } from '../../login/usuario/usuario.service';
import { IMateria } from '../../materia/materia.component';
import { MateriaService } from '../../materia/materia.service';
import { IPeriodo } from '../../periodo/periodo.component';
import { PeriodoService } from '../../periodo/periodo.service';
import { DocenteService } from '../docente.service';

@Component({
  selector: 'app-materia-docente',
  templateUrl: './materia-docente.component.html',
  styleUrls: ['./materia-docente.component.css']
})
export class MateriaDocenteComponent implements OnInit {

  constructor(private materiaService: MateriaService, private docenteService: DocenteService,
    private usuarioService: UsuarioService, private periodoService: PeriodoService) { }
  idUsuario: number;
  correo: string;
  usuario: IUsuario;
  materiasDocente: IMateria[];
  periodos: IPeriodo[];

  ngOnInit(): void {
    const usuario = JSON.parse(localStorage.getItem('user'));
    this.idUsuario = usuario["id"];
    this.usuarioService.getUsuarioId(this.idUsuario).subscribe(user => {
      this.materiaService.GetMateriaDocente(user.correo).subscribe(materias => this.materiasDocente = materias);
    });

    this.periodoService.getPeriodos().subscribe(periodos => this.periodos = periodos);
  }

}
