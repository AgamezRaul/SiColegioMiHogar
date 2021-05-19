import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Location } from '@angular/common';
import { IContrato, IContratos } from '../contrato.component';
import { ContratoService } from '../contrato.service';
import { error } from '@angular/compiler/src/util';
import Swal from 'sweetalert2';
import { MensajesModule } from '../../mensajes/mensajes.module';

@Component({
  selector: 'app-table-contrato',
  templateUrl: './table-contrato.component.html',
  styleUrls: ['./table-contrato.component.css']
})
export class TableContratoComponent implements OnInit {
  suscription: Subscription;
  contratos!: IContratos[];

  contrato!: IContrato[];
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
    private activatedRoute: ActivatedRoute, private location: Location,  private mensaje: MensajesModule) { }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit(): void {
    this.cargarData();
  }

  delete(contrato: IContrato) {
    this.contratoService.deleteContrato(contrato.idDocente)
      .subscribe(materia => this.cargarData()),
      error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString());


  }

  cargarData() {
    this.contratoService.getContratos()
      .subscribe(contratos => this.dataSource.data = contratos,
        error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));
  }
}
