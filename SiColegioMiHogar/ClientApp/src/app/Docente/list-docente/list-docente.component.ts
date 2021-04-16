import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { IDocente, IDocente2 } from '../docente.component';
import { DocenteService } from '../docente.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-list-docente',
  templateUrl: './list-docente.component.html',
  styleUrls: ['./list-docente.component.css']
})
export class ListDocenteComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  docente!: IDocente[];
  displayedColumns: string[] = [
    'Id',
    'NombreCompleto',
    'NumTarjetaProf',
    'Cedula',
    'Celular',
    'Correo',
    'Direccion'];
  dataSource = new MatTableDataSource<IDocente2>(this.docente);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private docenteservice: DocenteService, private router: Router, private activatedRoute: ActivatedRoute, private location: Location) { }
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
        error => console.error(error));

    this.suscription = this.docenteservice.refresh$.subscribe(() => {
      this.docenteservice.getDocentes()
        .subscribe(docente => this.dataSource.data = this.docente,
          error => console.error(error));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('observable cerrado');
  }
  Registrar() {
    this.router.navigate(["/registrar-Docente/" + this.id]);
  }
  Eliminar(idDocente: number) {
    this.docenteservice.deleteDocente(idDocente).
      subscribe(nit => this.onDeleteSuccess(),
        error => console.error(error))
  }
  onDeleteSuccess() {
    this.router.navigate(["/consultar-curso/" + this.id]);
  }
  

}