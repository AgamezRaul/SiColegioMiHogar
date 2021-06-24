import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { IMensualidad, IMensualidadVista } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { MensajesModule } from '../../mensajes/mensajes.module';

@Component({
  selector: 'app-list-mensualidad',
  templateUrl: './list-mensualidad.component.html',
  styleUrls: ['./list-mensualidad.component.css']
})
export class ListMensualidadComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  mensualidad!: IMensualidadVista[];
  displayedColumns: string[] = [
    'id',
    'estudiante',
    'mes',
    'deuda',
    'estado',
    'totalMensualidad',
    'correo',
    'options'];
  dataSource = new MatTableDataSource<IMensualidadVista>(this.mensualidad);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private mensualidadservice: MensualidadService, private router: Router,
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
    this.ConsultarMensualidad(this.id);

    this.suscription = this.mensualidadservice.refresh$.subscribe(() => {
      this.ConsultarMensualidad(this.id);
    });
  }
  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }
  Registrar() {
    this.router.navigate(["/registrar-mensualidad/" + this.id]);
  }

  Eliminar(idMensualidad: number) {
    this.mensualidadservice.deleteMensualidad(idMensualidad).
      subscribe(nit => this.onDeleteSuccess(),
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }

  onDeleteSuccess() {
    this.router.navigate(["/consultar-mensualidad/" + this.id]);
    this.mensaje.mensajeAlertaCorrecto('¡Exitoso!','Mensualidad elimindad correctamente');
  }
  onSaveSuccess() {
    this.router.navigate(["/consultar-mensualidad/" + this.id]);
    this.mensaje.mensajeAlertaCorrecto('¡Exitoso!', 'Correo eviado correctamente');
  }
  ConsultarMensualidad(idt: number) {
    this.mensualidadservice.getMensualidadesMatricula(idt)
      .subscribe(mensualidades => this.dataSource.data = mensualidades,
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }
  EnviarMail(mensualidad: IMensualidadVista, correo: string) {
    this.mensualidadservice.EnviarEmail(mensualidad, correo)
      .subscribe(mensualidad => this.onSaveSuccess()),
      error => this.mensaje.mensajeAlertaError('Error', error.error.toString());

  }

}
