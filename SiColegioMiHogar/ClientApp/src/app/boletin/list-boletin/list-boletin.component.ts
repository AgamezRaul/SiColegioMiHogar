import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IBoletin2 } from '../boletin.component';
import { BoletinService } from '../boletin.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list-boletin',
  templateUrl: './list-boletin.component.html',
  styleUrls: ['./list-boletin.component.css']
})
export class ListBoletinComponent implements OnInit {

  boletin!: IBoletin2[];

  displayedColumns: string[] = [
    'id',
    'idEstudiante',
    'fechaGeneracion',
    'idPeriodo'];
  dataSource = new MatTableDataSource<IBoletin2>(this.boletin);
  constructor(private boletinservice: BoletinService, private alertService: AlertService,
    private router: Router, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.cargardata();
  }

  cargardata() {
    this.boletinservice.getBoletines()
      .subscribe(boletin => { console.log(boletin), this.dataSource.data = boletin },
        error => this.alertService.error(error));
    console.table(this.boletin);
  }

}
