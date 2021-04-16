import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { IPeriodo } from '../periodo.component';
import { PeriodoService } from '../periodo.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';

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
    private activatedRoute: ActivatedRoute, private location: Location) { }

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
      subscribe(periodos =>  this.dataSource.data = periodos,
        error => console.error(error));
  }

  Registrar() {
    this.router.navigate(["/registrar-periodo/"]);
  }


}
