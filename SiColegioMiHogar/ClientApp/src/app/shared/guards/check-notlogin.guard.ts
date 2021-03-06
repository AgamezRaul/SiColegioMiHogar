import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../../login/login.service';
import { take, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CheckNotloginGuard implements CanActivate {
  constructor(private authService: LoginService, private router: Router) { }
  isLogged: boolean;

  canActivate(): boolean {
    this.authService.isLogged.subscribe(
      isLogged => this.isLogged = isLogged,
      error => console.log(error));
    if (!this.isLogged) {
      this.router.navigate(['login']);
    }
    return this.isLogged;
  }
}

/**
@Injectable()
export class CanActivateAuthGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(): boolean {
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser) {
      return true;
    } else {
      this.router.navigate(['/login/login']);
      return false;
    }
  }
}
 */
