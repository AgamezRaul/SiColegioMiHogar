import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { MensajesModule } from '../mensajes/mensajes.module';
import { Location } from '@angular/common';
import { AlertService } from '../notifications/_services';
import { ActivatedRoute, Router } from '@angular/router';
import { NotasActividadService } from './notas-actividad.service';
import { INota} from '../nota/nota.component';


@Component({
  selector: 'app-notas-actividad',
  templateUrl: './notas-actividad.component.html',
  styleUrls: ['./notas-actividad.component.css']
})
export class NotasActividadComponent implements OnInit {

  nota!: INota[];
  suscription: Subscription;
  displayedColumns: string[] = [
    'id',
    'NotaAlumno',
    'FechaNota',
    'IdEstudiante'
  ];

  dataSource = new MatTableDataSource<INota>(this.nota);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;


  constructor(private notasActividadService: NotasActividadService, private dialog: MatDialog, private mensaje: MensajesModule,  private router: Router,
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

  ida: number;


  ngOnInit(): void {
  	this.activatedRoute.params.subscribe(params => {
      if (params["idActividad"] == undefined) {
        return;
      }
      this.ida = parseInt(params["idActividad"]);
    })

    this.notasActividadService.getNotasActividad(this.ida)
      .subscribe(notas => this.dataSource.data = notas,
        error => this.mensaje.mensajeAlertaError('Error', error.error.toString()));
  }

}
