import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { MensajesModule } from '../../mensajes/mensajes.module';
import { IActividad } from '../../actividad/actividad.component';
import { ActividadService } from '../../actividad/actividad.service';
import { DialogoActividadComponent } from '../../actividad/dialogo-actividad/dialogo-actividad.component';
import { Location } from '@angular/common';
import { AlertService } from '../../notifications/_services';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-actividades',
  templateUrl: './actividades.component.html',
  styleUrls: ['./actividades.component.css']
})
export class ActividadesComponent implements OnInit {

  actividad!: IActividad[];
  suscription: Subscription;
  displayedColumns: string[] = [
    'id',
    'descripcion',
    'porcentaje',
    'idMateria',
    'idPeriodo',
    'nota'];
  dataSource = new MatTableDataSource<IActividad>(this.actividad);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private actividadService: ActividadService, private dialog: MatDialog, private mensaje: MensajesModule,  private router: Router,
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

  idm: number;

  ngOnInit(): void {

   	this.activatedRoute.params.subscribe(params => {
      if (params["idMateria"] == undefined) {
        return;
      }
      this.idm = parseInt(params["idMateria"]);
    })

    this.actividadService.getActividadMateria(this.idm)
      .subscribe(prematriculas => this.dataSource.data = prematriculas,
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));

    this.suscription = this.actividadService.refresh$.subscribe(() => {
      this.actividadService.getActividadMateria(this.idm).
        subscribe(prematriculas => this.dataSource.data = prematriculas,
          error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
    });
  }

 
  openDialog(id: number) {
    const detallesVista = this.dialog.open(DialogoActividadComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idActividad = id;
  }

}
