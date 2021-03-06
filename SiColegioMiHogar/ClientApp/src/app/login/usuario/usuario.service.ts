import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUsuario } from './usuario.component';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  apiURL = this.baseUrl + "api/Usuario";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getUsuarios(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.apiURL);
  }
  
  getUsuario(correo: number): Observable<IUsuario> {
    return this.http.get<IUsuario>(this.apiURL + '/' + correo);
  }
  getUsuarioId(id: number): Observable<IUsuario> {
    return this.http.get<IUsuario>(this.apiURL + '/GetUsuarioId/' + id);
  }
  createUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.post<IUsuario>(this.apiURL, usuario);
  }

  updateUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.put<IUsuario>(this.apiURL + "/" + usuario.id, usuario);
  }
  
  deleteUsuario(correo: string): Observable<IUsuario> {
    return this.http.delete<IUsuario>(this.apiURL + "/" + correo.toString());
  }
}
