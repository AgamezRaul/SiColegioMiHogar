import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { IMatricula } from '../matricula.component';
import { MatriculaService } from '../matricula.service';

@Component({
  selector: 'app-table-matricula',
  templateUrl: './table-matricula.component.html',
  styleUrls: ['./table-matricula.component.css']
})
export class TableMatriculaComponent implements OnInit {

  matricula!: IMatricula[];
  displayedColumns: string[] = [
    'nomEstudiante',
    'fecMatricula',
    'options'];
  dataSource = new MatTableDataSource<IMatricula>(this.matricula);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private matriculaService: MatriculaService, private router: Router) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.matriculaService.getMatriculas()
      .subscribe(matriculas => this.dataSource.data = matriculas,
        error => console.error(error));
  }
}