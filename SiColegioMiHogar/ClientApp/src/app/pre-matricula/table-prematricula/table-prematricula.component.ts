import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PreMatriculaService } from '../pre-matricula.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IPrematricula2 } from '../form-pre-matricula/form-pre-matricula.component';
import { CdkColumnDef } from '@angular/cdk/table';
@Component({
  selector: 'app-table-prematricula',
  templateUrl: './table-prematricula.component.html',
  styleUrls: ['./table-prematricula.component.css']
})
export class TablePrematriculaComponent implements OnInit {

  prematricula!: IPrematricula2[];
  displayedColumns: string[] = [
    'nomEstudiante',
    'fecPrematricula',
    'estado',];
  dataSource = new MatTableDataSource<IPrematricula2>(this.prematricula);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private prematriculaService: PreMatriculaService, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.prematriculaService.tablaPrematricula()
      .subscribe(prematriculas => this.dataSource.data = prematriculas,
        error => console.error(error)); console.log(this.dataSource.data);

  }
}
