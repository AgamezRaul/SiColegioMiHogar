import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogoActividadComponent } from './dialogo-actividad/dialogo-actividad.component';


@Component({
  selector: 'app-actividad',
  templateUrl: './actividad.component.html',
  styleUrls: ['./actividad.component.css']
})
export class ActividadComponent implements OnInit {
  idPeriodo: number;
  idMateria: number;
  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private dialog: MatDialog  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.idPeriodo = parseInt(params["idPeriodo"]);
      this.idMateria = parseInt(params["idMateria"]);
    })
    
  }
  openDialog() {
    const detallesVista = this.dialog.open(DialogoActividadComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idMateria = this.idMateria;
    detallesVista.componentInstance.idPeriodo = this.idPeriodo;

  }
}

export interface IActividad {
  id: number,
  descripcion: string,
  porcentaje: number,
  idMateria: number,
  idPeriodo: number
}
