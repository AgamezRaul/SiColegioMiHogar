import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PreMatriculaService } from '../pre-matricula.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatriculaService } from '../../matricula/matricula.service';
import { IPrematricula, IPrematricula2 } from '../pre-matricula.component';
import { AlertService } from '../../notifications/_services';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-table-prematricula',
  templateUrl: './table-prematricula.component.html',
  styleUrls: ['./table-prematricula.component.css']
})
export class TablePrematriculaComponent implements OnInit {
  prematricula3: IPrematricula;
  prematricula!: IPrematricula2[];
  suscription: Subscription;
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
    private activatedRoute: ActivatedRoute, private matriculaService: MatriculaService,
    private alertService: AlertService  ) { }

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
        error => this.alertService.error(error));

    this.suscription = this.prematriculaService.refresh$.subscribe(() => {
      this.prematriculaService.getPrematriculas().
        subscribe(prematriculas => this.dataSource.data = prematriculas,
          error => this.alertService.error(error));
    });
    
  }

  VerPreMatricula(idPreMatricula: number) {
    this.prematriculaService.getPrematricula(idPreMatricula).
      subscribe(prematricula => this.prematricula3 = prematricula,
        error => this.alertService.error(error.error));
  }

  CrearMatricula(idPreMatricula: number) {
    this.matriculaService.createMatricula(idPreMatricula).
      subscribe(empleadoId => this.onCrearMatriculaSuccess(),
        error => this.alertService.error(error.error))
  }

  onCrearMatriculaSuccess() {
    this.router.navigate(["/matricula"]);
    this.alertService.success("Guardado exitoso");
  }

  Eliminar(idUsuario: number) {
    this.prematriculaService.deletePreMatricula(idUsuario).
      subscribe(nit => this.onDeleteSuccess(),
        error => this.alertService.error(error.error));
  }

  onDeleteSuccess() {
    this.router.navigate(["/prematricula"]);
    this.alertService.success("Eliminado exitoso");
  }
}
