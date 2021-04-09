import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { IMensualidad, IMensualidad2 } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';

@Component({
  selector: 'app-list-mensualidad',
  templateUrl: './list-mensualidad.component.html',
  styleUrls: ['./list-mensualidad.component.css']
})
export class ListMensualidadComponent implements OnInit {

  mensualidad!: IMensualidad2[];
  displayedColumns: string[] = [
    'estudiante',
    'mes',
    'diaPago',
    'fechaPago',
    'valorMensualidad',
    'descuentoMensualidad',
    'abono',
    'deuda',
    'estado',
    'totalMensualidad',
    'options'  ];
  dataSource = new MatTableDataSource<IMensualidad2>(this.mensualidad);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private mensualidadservice: MensualidadService, private router: Router) { }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit(): void {
    this.mensualidadservice.getMensualidades()
      .subscribe(mensualidades => this.dataSource.data = mensualidades,
        error => console.error(error));
  }
}

