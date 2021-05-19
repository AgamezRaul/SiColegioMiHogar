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
  isRole: string;
  roleAdmin: string;
  isLogged = false;

  private subscription: Subscription;

  fillerNavAdmin = [
    { name: "home", route: "", icon: "home" },
    { name: "Prematricula", route: "prematricula", icon: "" },
    { name: "Matriculas", route: "matricula", icon: "" },
    { name: "Cursos", route: "cursos", icon: "" },
    { name: "Periodos", route: "periodos", icon: "" },
    { name: "Docente", route:"Docente",icon:""},
    { name: "Materias", route: "materias", icon: "" },
    { name: "Notas", route: "listar-notas", icon: "" },
    { name: "Usuarios", route: "lista-usuario", icon: "" },
    { name: "NotaPeriodo", route: "lista-nota-periodo", icon: "" },
    { name: "UsuarioAdmin", route: "registrousuarioAdmin", icon: "" },
    { name: "UsuarioEstudiante", route: "registrar-usuario-estudiante", icon: "" },
    { name: "Contratos", route: "contrato", icon: "" },
    
  ]

  fillerNavDocente = [
    { name: "home", route: "", icon: "home" },
    { name: "Notas", route: "listar-notas", icon: "" }
  ]

  fillerNavResponsable = [
    { name: "home", route: "", icon: "home" },
    { name: "Prematricula", route: "prematricula", icon: "" }
    

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
    this.loginService.isLogged.subscribe((res) => (this.isLogged = res));
    if (this.isLogged) {
      this.loginService.isRole.subscribe((res) => { this.isRole = res; console.log("isRole: " + res); })
      this.loginService.isAdmin$.subscribe(res => { this.roleAdmin = res; console.log("isAdmin: "+ res) })
      if (this.isRole == "Admin") {

      } else if (this.isRole == "Docente") {

      } else if (this.isRole == "Estudiante") {

      }

    }    
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
    this.subscription.unsubscribe();
  }
  shouldRun = true;
}
