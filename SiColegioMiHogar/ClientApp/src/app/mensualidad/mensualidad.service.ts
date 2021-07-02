import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IMensualidad, IMensualidadVista } from './mensualidad.component';

@Injectable({
  providedIn: 'root'
})
export class MensualidadService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Mensualidad";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  getMensualidades(): Observable<IMensualidadVista[]> {
    return this.http.get<IMensualidadVista[]>(this.apiURL);
  }

  getMensualidadesMatricula(matricula: number): Observable<IMensualidadVista[]> {
    return this.http.get<IMensualidadVista[]>(this.apiURL + '/GetMensualidadesMatricula/' + matricula);
  }


  getMensualidad(idMensu: number): Observable<IMensualidad> {
    return this.http.get<IMensualidad>(this.apiURL + '/' + idMensu);
  }

  createMensualidad(mensualidad: IMensualidad): Observable<IMensualidad> {
    return this.http.post<IMensualidad>(this.apiURL, mensualidad);
  }

  updateMensualidad(mensualidad: IMensualidad): Observable<IMensualidad> {
    return this.http.put<IMensualidad>(this.apiURL + "/" + mensualidad.id, mensualidad);
  }

  deleteMensualidad(idMensualidad: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idMensualidad)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })

      );
  }
  EnviarEmail(mensualidad: IMensualidadVista, correo: string): Observable<IMensualidadVista> {
    return this.http.put<IMensualidadVista>(this.apiURL + '/PutEmail/' + correo,mensualidad);
  }
}
