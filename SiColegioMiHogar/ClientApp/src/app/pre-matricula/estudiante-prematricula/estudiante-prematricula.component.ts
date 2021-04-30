import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../login/login.service';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-estudiante-prematricula',
  templateUrl: './estudiante-prematricula.component.html',
  styleUrls: ['./estudiante-prematricula.component.css']
})
export class EstudiantePrematriculaComponent implements OnInit {

  constructor(private serviceUser: LoginService, private alertService: AlertService) { }
  idUsuario: number;
  ngOnInit(): void {
    this.idUsuario = this.serviceUser.getIdUser();
  }

}
