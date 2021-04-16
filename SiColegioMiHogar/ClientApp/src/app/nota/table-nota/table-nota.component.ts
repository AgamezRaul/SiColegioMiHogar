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

@Component({
  selector: 'app-table-nota',
  templateUrl: './table-nota.component.html',
  styleUrls: ['./table-nota.component.css']
})
export class TableNotaComponent implements OnInit, OnDestroy {

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
  
  constructor(private notaservice: NotaService, private router: Router, private activatedRoute: ActivatedRoute, private location: Location) {}
  
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
    
    this.notaservice.getNotas().subscribe(
      Response => {
        this.ListaNotas = Response;
        this.dataSource = new MatTableDataSource(Response);
        console.log(this.dataSource.data);
        this.dataSource.paginator = this.paginator;
      },error => console.error(error));

    this.suscription = this.notaservice.refresh$.subscribe(() => {
      this.notaservice.getNotas()
        .subscribe(notas => this.dataSource.data = notas,
          error => console.error(error));
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
    console.log('observable cerrado');
  }

  Registrar() {
    this.router.navigate(["/registrar-nota/"]);
  }


}