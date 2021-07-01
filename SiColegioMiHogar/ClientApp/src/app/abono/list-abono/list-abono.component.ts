import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IAbono, IAbonoVista } from '../abono.component';
import { AbonoService } from '../abono.service';
import { formatCurrency, getCurrencySymbol, Location } from '@angular/common';
@Component({
  selector: 'app-list-abono',
  templateUrl: './list-abono.component.html',
  styleUrls: ['./list-abono.component.css']
})
export class ListAbonoComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  abono!: IAbonoVista[];
  displayedColumns: string[] = [
    'id',
    'estudiante',
    'fechaPago',
    'valorAbono',
    'estadoAbono',
    'valorMatricula',
    'deuda',
    'options'];
  dataSource = new MatTableDataSource<IAbonoVista>(this.abono);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private abonoservice: AbonoService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location, private mensaje: MensajesModule) {
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
    this.ConsultarAbono(this.id);

    this.suscription = this.abonoservice.refresh$.subscribe(() => {
      this.ConsultarAbono(this.id);
    });
  }
  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }
  Registrar() {
    this.router.navigate(["/registrar-abono/" + this.id]);
  }

  Eliminar(idAbono: number, valorAbono: number) {
    let abono: IAbono;
    abono.id = idAbono;
    abono.valorAbono = valorAbono;
    this.abonoservice.AnularAbono(abono)
      .subscribe(abono => this.onDeleteSuccess(),
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }
  
  onDeleteSuccess() {
    this.router.navigate(["/consultar-abono/" + this.id]);
    this.mensaje.mensajeAlertaCorrecto('¡Exitoso!', 'Abono anulado correctamente');
  }
 
  ConsultarAbono(idt: number) {
    this.abonoservice.getAbonosMensualidad(idt)
      .subscribe(abonos => this.dataSource.data = abonos,
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }
}


