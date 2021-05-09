import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { IContrato } from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-table-contrato',
  templateUrl: './table-contrato.component.html',
  styleUrls: ['./table-contrato.component.css']
})
export class TableContratoComponent implements OnInit {

  ListaContratos: IContrato[] = [];

  suscription: Subscription;
  nota!: IContrato[];
  displayedColumns: string[] = [
    'id',
    'fechaInicio',
    'fechaFin',
    'sueldo',
    'idDocente',
    'Options'];
    dataSource = new MatTableDataSource<IContrato>(this.nota);
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private contratoService: ContratoService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location,
    private alertService: AlertService) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  
  ngOnInit(): void {
    this.contratoService.getContratos()
    .subscribe(contratos => this.dataSource.data = contratos,
      error => this.alertService.error(error));

    this.suscription = this.contratoService.refresh$.subscribe(() => {
      this.contratoService.getContratos()
        .subscribe(contratos => this.dataSource.data = contratos,
          error => this.alertService.error(error));
    });
  }

  Registrar() {
   
  }
}
