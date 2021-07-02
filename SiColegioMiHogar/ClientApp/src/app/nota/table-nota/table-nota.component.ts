import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { INotaConsult } from '../nota.component';
import { INota } from '../nota.component';
import { NotaService } from '../nota.service';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-table-nota',
  templateUrl: './table-nota.component.html',
  styleUrls: ['./table-nota.component.css']
})
export class TableNotaComponent implements OnInit {
   
  ListaNotas: INotaConsult[] = [];

  suscription: Subscription;
  nota!: INotaConsult[];
  displayedColumns: string[] = [
    'id',
    'descripcion',
    'notaAlumno',
    'fechaNota',
    'estudiante',
    'materia',
    'periodo',
    'Options'];
    dataSource = new MatTableDataSource<INotaConsult>(this.nota);
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private notaservice: NotaService, private router: Router,
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

  ngOnInit(): void {
    this.notaservice.getNotas()
        .subscribe(notas => this.dataSource.data = notas,
          error => this.alertService.error(error));

    this.suscription = this.notaservice.refresh$.subscribe(() => {
      this.notaservice.getNotas()
        .subscribe(notas => this.dataSource.data = notas,
          error => this.alertService.error(error));
    });
  }


  Registrar() {
    this.router.navigate(["/registrar-nota/"]);
  }
  

  Consultar(idlink){
    this.router.navigate(['/consultar-nota', { id: idlink }]);
  }

  Eliminar (id){
    this.suscription = this.notaservice.deleteNota(id)
      .subscribe(notas => this.onDeleteSuccess(),
        error => this.alertService.error(error));
  }

  onDeleteSuccess() {
    this.router.navigate(["/listar-notas"]);
    this.alertService.success("Nota eliminada exitosamente");
  }

}
