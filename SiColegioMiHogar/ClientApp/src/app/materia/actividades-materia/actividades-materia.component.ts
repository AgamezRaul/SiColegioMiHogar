import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IMateria } from '../../materia/materia.component';
import { MateriaService } from '../../materia/materia.service';
import { IUsuario } from '../../login/usuario/usuario.component';
import { UsuarioService } from '../../login/usuario/usuario.service';


@Component({
  selector: 'app-actividades-materia',
  templateUrl: './actividades-materia.component.html',
  styleUrls: ['./actividades-materia.component.css']
})

export class ActividadesMateriaComponent implements OnInit {
  
  materia!: IMateria[];

  displayedColumns: string[] = [
    'id',
    'nombreMateria',
    'options'];
  dataSource = new MatTableDataSource<IMateria>(this.materia);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private materiaService: MateriaService, private alertService: AlertService,
    private router: Router, private usuarioService: UsuarioService, private activatedRoute: ActivatedRoute) {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.cargardata();
  }

  idUsuario: number;
  correo: string;
  usuario: IUsuario;

  cargardata() {

    const usuario = JSON.parse(localStorage.getItem('user'));
    this.idUsuario = usuario["id"];
    this.usuarioService.getUsuarioId(this.idUsuario).subscribe(user => {
      this.materiaService.GetMateriaDocente(user.correo).subscribe(materias => this.dataSource.data = materias);
    });

  }
  
}