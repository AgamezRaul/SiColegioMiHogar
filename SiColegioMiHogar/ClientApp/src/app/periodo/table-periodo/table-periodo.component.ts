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

export class TablePeriodoComponent  implements OnInit, OnDestroy {

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
  
  constructor(private periodoservice: PeriodoService, private router: Router, private activatedRoute: ActivatedRoute, private location: Location) {}
  
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
    
    this.periodoservice.getPeriodos().subscribe(
      Response => {
        this.ListaPeriodos = Response;
        this.dataSource = new MatTableDataSource(Response);
        console.log(this.dataSource.data);
        this.dataSource.paginator = this.paginator;
      },error => console.error(error));

    this.suscription = this.periodoservice.refresh$.subscribe(() => {
      this.periodoservice.getPeriodos()
        .subscribe(periodos => this.dataSource.data = periodos,
          error => console.error(error));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('observable cerrado');
  }

  Registrar() {
    this.router.navigate(["/registrar-periodo/"]);
  }


}
