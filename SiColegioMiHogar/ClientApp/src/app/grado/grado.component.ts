import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grado',
  templateUrl: './grado.component.html',
  styleUrls: ['./grado.component.css']
})
export class GradoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
export interface IGrado {
  id: number,
  nombre: string

}
