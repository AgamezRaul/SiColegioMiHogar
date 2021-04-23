import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../../login/login.service';

@Injectable({
  providedIn: 'root'
})
export class IsResponsableGuard implements CanActivate {
  constructor(private authService: LoginService, private router: Router) { }
  roleUser: string;
  canActivate(): boolean {
    this.authService.isRole.subscribe(
      rol => this.roleUser = rol,
      error => console.log(error));

    if (this.roleUser == "Responsable") {
      return true;
    } else {
      this.router.navigate(['/']);
      return false;
    }
  }
  
}
