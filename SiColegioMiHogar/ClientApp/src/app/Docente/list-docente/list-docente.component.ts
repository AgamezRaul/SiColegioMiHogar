import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { DocenteService } from '../docente.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { IDocente } from '../docente.component';
import Swal from 'sweetalert2';
import { MensajesModule } from '../../mensajes/mensajes.module';
@Component({
  selector: 'app-list-docente',
  templateUrl: './list-docente.component.html',
  styleUrls: ['./list-docente.component.css']
})
export class ListDocenteComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  docente!: IDocente[];
  displayedColumns: string[] = [
    'id',
    'nombreCompleto',
    'numTarjetaProf',
    'cedula',
    'celular',
    'correo',
    'direccion',
    'options'  ];
  dataSource = new MatTableDataSource<IDocente>(this.docente);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private docenteservice: DocenteService, private router: Router,
    private activatedRoute: ActivatedRoute, private location: Location,
    private mensaje: MensajesModule) { }
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
    this.docenteservice.getDocentes()
      .subscribe(docentes => this.dataSource.data = docentes,
        error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));

    this.suscription = this.docenteservice.refresh$.subscribe(() => {
      this.docenteservice.getDocentes()
        .subscribe(docente => this.dataSource.data = this.docente,
          error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('Observable cerrado');
  }
  Registrar() {
    this.router.navigate(["/registrar-docente/"]);
  }
  Eliminar(idDocente: number) {
    this.docenteservice.deleteDocente(idDocente).
      subscribe(nit => this.onDeleteSuccess(),
        error => this.mensaje.mensajeAlertaError('¡Error!', error.error.toString()));
  }
  onDeleteSuccess() {
    this.router.navigate(["/Docente"]);
    this.mensaje.mensajeAlertaCorrecto('¡Exitoso!', 'Docente eliminado correctamente');
  }
  

}
