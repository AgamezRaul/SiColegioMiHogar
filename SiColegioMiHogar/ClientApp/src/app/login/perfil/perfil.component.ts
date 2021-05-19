import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  isLogged = false;
  isAdmin = null;
  id: number;
  usuario: any;

  //Cancelar subscripciones para ahorrar memoria 
  private subscription: Subscription;

  constructor(private loginService: LoginService, private router: Router) {
    this.subscription = new Subscription();
  }

  ngOnInit() {
    this.subscription.add(
      this.loginService.isLogged.subscribe((res) => (this.isLogged = res))
    );
    this.subscription.add(
      this.loginService.isAdmin$.subscribe((res) => (this.isAdmin = res))
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  public Logout() {
    this.loginService.logout();
  }
  Actualizar() {
    this.usuario = JSON.parse(localStorage.getItem("user"));
    this.id = this.usuario["id"];
    this.router.navigate(["/editar-Usuario/" + this.id]);
  }

}
