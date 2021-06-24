import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { IPeriodo } from '../periodo.component';
import { PeriodoService } from '../periodo.service';
import { Location } from '@angular/common';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-table-periodo',
  templateUrl: './table-periodo.component.html',
  styleUrls: ['./table-periodo.component.css']
})

export class TablePeriodoComponent  implements OnInit {

  ListaPeriodos: IPeriodo[] = [];

  suscription: Subscription;
  periodo!: IPeriodo[];
  displayedColumns: string[] = [
    'id',
    'numeroPeriodo',
    'nombrePeriodo',
    'fechaInicio',
    'fechaFin',
    'Options'];
    dataSource = new MatTableDataSource<IPeriodo>(this.periodo);
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private periodoservice: PeriodoService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location,
    private alertService: AlertService  ) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {    
    this.periodoservice.getPeriodos().
      subscribe(periodos =>  this.formatoFecha(periodos),
        error => this.alertService.error(error));
  }

  formatoFecha(periodos: IPeriodo[]) {
      periodos.forEach(element => element.fechaInicio = element.fechaInicio.split('T')[0]);
      periodos.forEach(element => element.fechaInicio = element.fechaInicio.split('-').reverse().join('-'));
      periodos.forEach(element => element.fechaFin = element.fechaFin.split('T')[0]);
      periodos.forEach(element => element.fechaFin = element.fechaFin.split('-').reverse().join('-'));
      this.dataSource.data = periodos
  }

  Registrar() {
    this.router.navigate(["/registrar-periodo/"]);
    this.alertService.success("Guardado exitoso");
  }

  Eliminar (id){
    this.suscription = this.periodoservice.deletePeriodo(id)
      .subscribe(notas => this.onDeleteSuccess(),
        error => this.alertService.error(error));
  }

  onDeleteSuccess() {
    this.router.navigate(["/periodos"]);
    this.alertService.success("Eliminado exitoso");
  }

}
