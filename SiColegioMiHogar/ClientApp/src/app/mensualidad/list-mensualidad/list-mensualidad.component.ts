import { Component, OnInit } from '@angular/core';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';

@Component({
  selector: 'app-list-mensualidad',
  templateUrl: './list-mensualidad.component.html',
  styleUrls: ['./list-mensualidad.component.css']
})
export class ListMensualidadComponent implements OnInit {
  mensualidades: IMensualidad[];
  constructor(private mensualidadservice: MensualidadService) { }

  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.mensualidadservice.getMensualidades().subscribe(mensualidades => this.mensualidades = mensualidades);
  }

}

