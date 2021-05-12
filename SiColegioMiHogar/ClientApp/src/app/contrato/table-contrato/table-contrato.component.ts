import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AlertService } from '../../notifications/_services';
import { Location } from '@angular/common';
import { IContratos } from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { error } from '@angular/compiler/src/util';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-table-contrato',
  templateUrl: './table-contrato.component.html',
  styleUrls: ['./table-contrato.component.css']
})
export class TableContratoComponent implements OnInit {
  suscription: Subscription;
  contratos!: IContratos[];
  displayedColumns: string[] = [
    'id',
    'nombreDocente',
    'sueldo',
    'fechaInicio',
    'fechaFin',
    'options'];
  dataSource = new MatTableDataSource<IContratos>(this.contratos);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private contratoService: ContratoService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location, private alertService: AlertService) { }
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
        error => this.mensajeAlertaError('Error', error.error.toString()));
  }
  mensajeAlertaCorrecto(titulo: string, texto: string) {
    Swal.fire({
      icon: 'success',
      title: titulo,
      text: texto,
    });
  }
  mensajeAlertaError(titulo: string, texto: string) {
    Swal.fire({
      icon: 'error',
      title: titulo,
      text: texto,
    });
  }
}
