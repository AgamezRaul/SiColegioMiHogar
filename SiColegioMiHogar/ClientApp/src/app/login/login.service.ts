import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { catchError, map } from "rxjs/operators";
import { isNullOrUndefined } from "util";

import { Roles, User, UserResponse } from "src/app/login/user-interface";
import { BehaviorSubject, throwError } from "rxjs";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Router } from "@angular/router";
import { AlertService } from "../notifications/_services";
import { SidenavMenuComponent } from "../sidenav-menu/sidenav-menu.component";

const helper = new JwtHelperService();
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  apiURL = this.baseUrl + "api/Login";
  private loggedIn = new BehaviorSubject<boolean>(false);
  private role = new BehaviorSubject<Roles>(null);
  get isLogged(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
  get isAdmin$(): Observable<string> {
    return this.role.asObservable();
  }
  get isRole(): Observable<string> {
    return this.role;
  }
  constructor(private htttp: HttpClient, private router: Router, private alertService: AlertService,
    @Inject('BASE_URL') private baseUrl: string) { this.checkToken(); }

  login(authData: User): Observable<UserResponse | void> {
    return this.htttp
      .post<UserResponse>(this.apiURL, authData)
      .pipe(
        map((user: UserResponse) => {
          this.saveLocalStorage(user);
          this.loggedIn.next(true);
          this.role.next(user.tipoUsuario);
          return user;

        }),
        catchError((err) => this.handlerError(err))
      );
  }

  getIdUser(): number{
    const user = JSON.parse(localStorage.getItem('user')) || null;//<--- si no existe user sera null
    if (user) {
      return user.id;
    }
    else {
      return 0;
    }
  }z

  logout(): void {
    localStorage.removeItem('user');
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

  private checkToken(): void {
    const user = JSON.parse(localStorage.getItem('user')) || null;//<--- si no existe user sera null
    if (user) {
      const isExpired = helper.isTokenExpired(user.token);//<-el token expiro?
      //si expiro destruir el token 
      if (isExpired) {
        this.logout();
      } else {
        this.loggedIn.next(true);
        this.role.next(user.rol)
      }
    }
    //isExpired ?this.logout():this.loggedIn.next(true);
    //console.log('Expiro el Token->', isExpired);
  }

  private saveLocalStorage(user: UserResponse): void {
    const { message, ...rest } = user;
    localStorage.setItem('user', JSON.stringify(rest));
  }
  private handlerError(err): Observable<never> {
    let errorMessage = 'An errror occured retrienving data';
    if (err) {
      this.alertService.error(err.error)
    }
    return throwError(errorMessage);
  }
}
