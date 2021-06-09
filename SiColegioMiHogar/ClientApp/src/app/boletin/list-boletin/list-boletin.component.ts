import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IBoletin2 } from '../boletin.component';
import { BoletinService } from '../boletin.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import Swal from 'sweetalert2';
import { Location } from '@angular/common';
import { Subscription } from 'rxjs';
import { MensajesModule } from '../../mensajes/mensajes.module';
@Component({
  selector: 'app-list-boletin',
  templateUrl: './list-boletin.component.html',
  styleUrls: ['./list-boletin.component.css']
})
export class ListBoletinComponent implements OnInit {
  suscription: Subscription;
  boletin!: IBoletin2[];
  displayedColumns: string[] = [
    'id',
    'nomEstudiante',
    'ideEstudiante',
    'gradoEstudiante',
    'nombrePeriodo',
    'fechaGeneracion'  ];
  
  dataSource = new MatTableDataSource<IBoletin2>(this.boletin);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private boletinservice: BoletinService, private alertService: AlertService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private mensaje: MensajesModule  ) {
  }

  ngOnInit(): void {
    this.cargardata();
  }

  cargardata() {
    this.boletinservice.getBoletines()
      .subscribe(boletin => {console.log(boletin)
        , this.dataSource.data = boletin
      },
        error => this.alertService.error(error));
    console.table(this.boletin); 
  }

  
  Registrar() {
    this.router.navigate(["/registrar-boletin"]);
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
