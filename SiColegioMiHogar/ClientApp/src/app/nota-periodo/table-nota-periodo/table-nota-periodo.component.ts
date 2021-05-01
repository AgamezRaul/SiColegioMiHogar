import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { AlertService } from '../../notifications/_services';
import { error } from 'console';
import { INotaPeriodo2 } from '../nota-periodo.component';
import { NotaPeriodoService } from '../nota-periodo.service';

@Component({
  selector: 'app-table-nota-periodo',
  templateUrl: './table-nota-periodo.component.html',
  styleUrls: ['./table-nota-periodo.component.css']
})
export class TableNotaPeriodoComponent implements OnInit {

  suscription: Subscription;
  notaPeriodo!: INotaPeriodo2[];
  displayedColumns: string[] = [
    'nota',
    'observacion',
    'nombrePeriodo',
    'nombreMateria',
    'options'];
  dataSource = new MatTableDataSource<INotaPeriodo2>(this.notaPeriodo);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private notaperiodoservice: NotaPeriodoService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location,
    private alertService: AlertService) {
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
    this.notaperiodoservice.getNotasPeriodos()
      .subscribe(notasPeriodos => this.dataSource.data = notasPeriodos,
        error => this.alertService.error(error));

    this.suscription = this.notaperiodoservice.refresh$.subscribe(() => {
      this.notaperiodoservice.getNotasPeriodos()
        .subscribe(notasPeriodos => this.dataSource.data = notasPeriodos,
          error => this.alertService.error(error));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('observable cerrado');
  }
  Registrar() {
    this.router.navigate(["/registrar-notaPeriodo"]);
  }

  Eliminar(idNotaPeriodo: number) {
    this.notaperiodoservice.deleteNotaPeriodo(idNotaPeriodo).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error));
  }
  onDeleteSuccess() {
    this.router.navigate(["/notasperiodos"]);
    this.alertService.success("Eliminado exitoso");
  }

}
