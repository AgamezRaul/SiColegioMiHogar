import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IMateria } from '../materia.component';
import { MateriaService } from '../materia.service';


@Component({
  selector: 'app-list-materia',
  templateUrl: './list-materia.component.html',
  styleUrls: ['./list-materia.component.css']
})
export class ListMateriaComponent implements OnInit {

  materia!: IMateria[];

  displayedColumns: string[] = [
    'id',
    'nombreMateria',
    'idDocente',
    'idCurso',
    'options'];
  dataSource = new MatTableDataSource<IMateria>(this.materia);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private materiaService: MateriaService, private alertService: AlertService,
    private router: Router, private activatedRoute: ActivatedRoute) {
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

  Registrar() {
    this.router.navigate(["/registrar-materia"]);
  }

  delete(materia: IMateria) {
    this.materiaService.deleteMateria(materia.id)
      .subscribe(materia => this.cargardata()),
      error => this.alertService.error(error.error);

    console.table(materia);
  }

  cargardata() {
    this.materiaService.getMaterias()
      .subscribe(materia => { console.log(materia), this.dataSource.data = materia },
        error => this.alertService.error(error.error));
  }
}
