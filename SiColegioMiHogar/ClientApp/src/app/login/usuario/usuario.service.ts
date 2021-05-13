import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUsuario, IUsuario2 } from './usuario.component';

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
  getUsuario2(id: number): Observable<IUsuario2> {
    return this.http.get<IUsuario2>(this.apiURL + '/GetUsuario2/' + id);
  }
  createUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.post<IUsuario>(this.apiURL, usuario);
  }

  updateUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.put<IUsuario>(this.apiURL + "/" + usuario.correo.toString(), usuario);
  }
  updateUsuario2(usuario: IUsuario2): Observable<IUsuario> {
    return this.http.put<IUsuario>(this.apiURL + "/2/" + usuario.id, usuario);
  }
  
  deleteUsuario(correo: string): Observable<IUsuario> {
    return this.http.delete<IUsuario>(this.apiURL + "/" + correo.toString());
  }
}
