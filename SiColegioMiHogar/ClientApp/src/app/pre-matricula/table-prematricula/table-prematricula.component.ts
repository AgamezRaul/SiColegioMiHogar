import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PreMatriculaService } from '../pre-matricula.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatriculaService } from '../../matricula/matricula.service';
import { IPrematricula, IPrematricula2 } from '../pre-matricula.component';

@Component({
  selector: 'app-table-prematricula',
  templateUrl: './table-prematricula.component.html',
  styleUrls: ['./table-prematricula.component.css']
})
export class TablePrematriculaComponent implements OnInit {
  prematricula3: IPrematricula;
  prematricula!: IPrematricula2[];
  displayedColumns: string[] = [
    'idUsuario',
    'idPrematricula',
    'nomEstudiante',
    'fecPrematricula',
    'estado',
    'options'];
  dataSource = new MatTableDataSource<IPrematricula2>(this.prematricula);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private prematriculaService: PreMatriculaService, private router: Router,
    private activatedRoute: ActivatedRoute, private matriculaService: MatriculaService) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.prematriculaService.getPrematriculas()
      .subscribe(prematriculas => this.dataSource.data = prematriculas,
        error => console.error(error));
  }

  VerPreMatricula(idPreMatricula: number) {
    this.prematriculaService.getPrematricula(idPreMatricula).
      subscribe(prematricula => this.prematricula3 = prematricula,
        error => console.error(error));
    console.log(this.prematricula3);
  }

  CrearMatricula(idPreMatricula: number) {
    this.matriculaService.createMatricula(idPreMatricula).
      subscribe(empleadoId => this.onCrearMatriculaSuccess(),
        error => console.error(error))
  }

  onCrearMatriculaSuccess() {
    this.router.navigate(["/matricula"]);
  }

  Eliminar(idUsuario: number) {
    this.prematriculaService.deletePreMatricula(idUsuario).
      subscribe(nit => this.onDeleteSuccess(),
        error => console.error(error))
  }

  onDeleteSuccess() {
    this.router.navigate(["/prematricula"]);
  }
}
