import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMensualidad, IMensualidad2 } from './mensualidad.component';

@Injectable({
  providedIn: 'root'
})
export class MensualidadService {

  apiURL = this.baseUrl + "api/Mensualidad";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getMensualidades(): Observable<IMensualidad2[]> {
    return this.http.get<IMensualidad2[]>(this.apiURL);
  }

  getMensualidadesMatricula(matricula: number): Observable<IMensualidad2[]> {
    return this.http.get<IMensualidad2[]>(this.apiURL + '/GetMensualidadesMatricula/' + matricula);
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

  deleteMensualidad(mensualidad: IMensualidad): Observable<IMensualidad> {
    return this.http.put<IMensualidad>(this.apiURL + "/DeleteMensualidad" + "/" + mensualidad.mes.toString(), mensualidad);
  }

}
