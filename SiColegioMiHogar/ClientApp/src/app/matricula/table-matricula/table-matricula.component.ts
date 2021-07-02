import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { error } from 'console';
import { Subscription } from 'rxjs';
import { AlertService } from '../../notifications/_services';
import { IMatricula } from '../matricula.component';
import { MatriculaService } from '../matricula.service';

@Component({
  selector: 'app-table-matricula',
  templateUrl: './table-matricula.component.html',
  styleUrls: ['./table-matricula.component.css']
})
export class TableMatriculaComponent implements OnInit {

  matricula!: IMatricula[];
  suscription: Subscription;
  displayedColumns: string[] = [
    'nomEstudiante',
    'fecMatricula',
    'options'];
  dataSource = new MatTableDataSource<IMatricula>(this.matricula);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private matriculaService: MatriculaService, private router: Router,
    private alertService: AlertService ) { }

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
        error => this.alertService.error(error));

    this.suscription = this.matriculaService.refresh$.subscribe(() => {
      this.matriculaService.getMatriculas().
        subscribe(matriculas => this.dataSource.data = matriculas,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(idMatricula: number) {
    this.matriculaService.deleteMatricula(idMatricula).
      subscribe(nit => this.onDeleteSuccess(),
        error => this.alertService.error(error.error));
  }
  onDeleteSuccess() {
    this.router.navigate(["/matricula"]);
    this.alertService.success("Matricula eliminada exitosamente");
  }
}
