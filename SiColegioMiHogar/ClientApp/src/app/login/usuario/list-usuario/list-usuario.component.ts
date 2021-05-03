import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IUsuario } from '../usuario.component';
import { UsuarioService } from '../usuario.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-list-usuario',
  templateUrl: './list-usuario.component.html',
  styleUrls: ['./list-usuario.component.css']
})
export class ListUsuarioComponent implements OnInit {
  usuario!: IUsuario[];
  
  displayedColumns: string[] = [
    'correo',
    'tipoUsuario',
    'options'];
  dataSource = new MatTableDataSource<IUsuario>(this.usuario);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private usuarioService: UsuarioService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location, private alertService: AlertService) { }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit(): void {
    this.ConsultarUsuarios();
  }
  ConsultarUsuarios() {
    this.usuarioService.getUsuarios()
      .subscribe(usuarios => this.dataSource.data = usuarios,
        error => this.alertService.error(error.error));
  }

  delete(usuario: IUsuario) {
    this.usuarioService.deleteUsuario(usuario.correo)
      .subscribe(usuario => this.ConsultarUsuarios()),
      error => this.alertService.error(error);

    console.table(usuario);
  }


}
