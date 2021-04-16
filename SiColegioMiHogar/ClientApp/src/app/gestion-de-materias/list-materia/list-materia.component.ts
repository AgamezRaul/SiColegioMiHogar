import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { IMateria } from '../gestion-de-materias.component';
import { GestionDeMateriasService } from '../gestion-de-materias.service';

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
    'idCurso'];
  dataSource = new MatTableDataSource<IMateria>(this.materia);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private materiaservice: GestionDeMateriasService,
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
    this.materiaservice.getMaterias()
      .subscribe(materia => { console.log(materia), this.dataSource.data = materia },
        error => console.error(error));
  }

  Registrar() {
    this.router.navigate(["/registrar-materia"]);
  }
}
