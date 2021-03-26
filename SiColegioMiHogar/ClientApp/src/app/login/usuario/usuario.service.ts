import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUsuario } from './usuario.component';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  apiURL = this.baseUrl + "api/Empleado";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEmpleados(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.apiURL);
  }

  getEmpleado(correo: number): Observable<IUsuario> {
    return this.http.get<IUsuario>(this.apiURL + '/' + correo);
  }

  createEmpleado(usuario: IUsuario): Observable<IUsuario> {
    return this.http.post<IUsuario>(this.apiURL, usuario);
  }

  updateEmpleado(usuario: IUsuario): Observable<IUsuario> {
    return this.http.put<IUsuario>(this.apiURL + "/" + usuario.correo.toString(), usuario);
  }

}
