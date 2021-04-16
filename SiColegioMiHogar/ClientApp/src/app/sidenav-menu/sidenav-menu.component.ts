import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoginService } from '../login/login.service';

@Component({
  selector: 'app-sidenav-menu',
  templateUrl: './sidenav-menu.component.html',
  styleUrls: ['./sidenav-menu.component.css']
})
export class SidenavMenuComponent implements OnInit {
  mobileQuery: MediaQueryList;
  isAdmin = null;
  isLogged = false;

  private subscription: Subscription;

  fillerNav = [
    { name: "home", route: "", icon: "home" },
    { name: "Prematricula", route: "prematricula", icon: "" },
    { name: "Matriculas", route: "matricula", icon: "" },
    { name: "Cursos", route: "cursos", icon: "" },
    { name: "Periodos", route: "listar-periodos", icon: "" },
    { name: "Registrar Docente", route:"lista-docente",icon:""},
    { name: "Gestion de Materias", route: "materias", icon: "" },

    { name: "Notas", route: "listar-notas", icon: "" },
  ]
  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,
    private loginService: LoginService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.subscription = new Subscription();
  }
  ngOnInit() {
    this.subscription.add(
      this.loginService.isAdmin$.subscribe((res) => (this.isAdmin = res))
    );
    //this.subscription.add(
    this.loginService.isLogged.subscribe((res) => (this.isLogged = res));
    //);
  }
  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
    this.subscription.unsubscribe();
  }
  changeRole(): void {
    this.isAdmin = !this.isAdmin;
  }
  shouldRun = true;
}
