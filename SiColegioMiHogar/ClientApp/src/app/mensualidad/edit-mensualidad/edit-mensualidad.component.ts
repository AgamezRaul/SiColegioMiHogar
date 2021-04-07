import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMensualidad } from '../mensualidad.component';
import { MensualidadService } from '../mensualidad.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit-mensualidad',
  templateUrl: './edit-mensualidad.component.html',
  styleUrls: ['./edit-mensualidad.component.css']
})
export class EditMensualidadComponent implements OnInit {
  mensualidad: IMensualidad;
  mes: string;
  constructor(private route: ActivatedRoute,
    private mensualidadService: MensualidadService,
    private location: Location) { }

  ngOnInit() {
    this.get();
  }
  get(): void {
    const mes = +this.route.snapshot.paramMap.get('mes');
    this.mensualidadService.getMensualidad(mes).subscribe(hero => this.mensualidad = hero);
  }
  update(): void {
    this.mensualidadService.updateMensualidad(this.mensualidad).subscribe(() => this.goBack());
  }
 
  goBack(): void {
    this.location.back();
  }
  

}
