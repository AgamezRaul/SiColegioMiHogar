import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMensualidad } from './mensualidad.component';

@Injectable({
  providedIn: 'root'
})
export class MensualidadService {

  apiURL = this.baseUrl + "api/Mensualidad";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getMensualidades(): Observable<IMensualidad[]> {
    return this.http.get<IMensualidad[]>(this.apiURL);
  }

  getMensualidad(id: number): Observable<IMensualidad> {
    return this.http.get<IMensualidad>(this.apiURL + '/' + id);
  }

  createMensualidad(mensualidad: IMensualidad): Observable<IMensualidad> {
    return this.http.post<IMensualidad>(this.apiURL, mensualidad);
  }

  updateMensualidad(mensualidad: IMensualidad): Observable<IMensualidad> {
    return this.http.put<IMensualidad>(this.apiURL + "/" + mensualidad.id.toString(), mensualidad);
  }

  deleteMensualidad(id: number): Observable<number> {
    return this.http.put<number>(this.apiURL + "/DeleteMensualidad" + "/" + id.toString(),id);
  }

}
