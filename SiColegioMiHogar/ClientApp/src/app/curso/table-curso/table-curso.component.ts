import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ICurso, ICurso2 } from '../curso.component';
import { CursoService } from '../curso.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-table-curso',
  templateUrl: './table-curso.component.html',
  styleUrls: ['./table-curso.component.css']
})
export class TableCursoComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  curso!: ICurso2[];
  displayedColumns: string[] = [
    'Id',
    'NombreCurso',
    'MaximoEstudiantes',
    'IdDirector',
    'NombreDirector',
    'CedulaDirector',
    'Options'];
  dataSource = new MatTableDataSource<ICurso2>(this.curso);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private cursoservice: CursoService, private router: Router, private activatedRoute: ActivatedRoute, private location: Location) {
  }

  id: number;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.id = parseInt(params["id"]);
    })
    this.cursoservice.getCursoDocente(this.id)
      .subscribe(cursos => this.dataSource.data = cursos,
        error => console.error(error));

    this.suscription = this.cursoservice.refresh$.subscribe(() => {
      this.cursoservice.getCursoDocente(this.id)
        .subscribe(cursos => this.dataSource.data = cursos,
          error => console.error(error));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('observable cerrado');
  }
  Registrar() {
    this.router.navigate(["/registrar-curso/" + this.id]);
  }

  Eliminar(idCurso: number) {
    this.cursoservice.deleteCurso(idCurso).
      subscribe(nit => this.onDeleteSuccess(),
        error => console.error(error))
  }

  onDeleteSuccess() {
    this.router.navigate(["/consultar-curso/" + this.id]);
  }

}
