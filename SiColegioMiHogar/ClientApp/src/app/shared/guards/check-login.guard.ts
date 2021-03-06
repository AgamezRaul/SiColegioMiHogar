import { Injectable } from '@angular/core';
import { CanActivate} from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../../login/login.service';
import { take, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CheckLoginGuard implements CanActivate {
  constructor(private authService: LoginService) { }
  //puede acceder un usuario a tal ruta?
  canActivate(): Observable<boolean>{
    return this.authService.isLogged.pipe(
      take(1),
      map((isLogged: boolean) => !isLogged)
    );
  }
}
