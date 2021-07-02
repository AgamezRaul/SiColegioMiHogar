import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IValorMensualidad } from '../valor-mensualidad.component';
import { ValorMensualidadService } from '../valor-mensualidad.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-list-valor-mensualidad',
  templateUrl: './list-valor-mensualidad.component.html',
  styleUrls: ['./list-valor-mensualidad.component.css']
})
export class ListValorMensualidadComponent implements OnInit {

  valorMensualidad!: IValorMensualidad[];
  displayedColumns: string[] = [
    'id',
    'precioMensualidad',
    'anio',
    'grado',
    'options'];
  dataSource = new MatTableDataSource<IValorMensualidad>(this.valorMensualidad);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private valorMensualidadservice: ValorMensualidadService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location, private mensaje: MensajesModule) {
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
    this.ConsultarValorMensualidades()
  }
  ConsultarValorMensualidades() {
    this.valorMensualidadservice.getValorMensualidades()
      .subscribe(valorMensualidades => this.dataSource.data = valorMensualidades,
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }
  Registrar() {
    this.router.navigate(["/registrar-valorMensulidad"]);
  }
}
