import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

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
    { name: "Registro Prematricula", route: "registrar-prematricula", icon: "supervised_user_circle" },
    { name: "Registro Mensualidad", route: "form-mensualidad", icon: "supervised_user_circle" },
    { name: "Consulta Mensualidades", route: "list-mensualidad", icon: "supervised_user_circle" },
    

  ]
  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.subscription = new Subscription();
  }
  ngOnInit() {
  }
  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
    this.subscription.unsubscribe();
  }
  shouldRun = true;
}
