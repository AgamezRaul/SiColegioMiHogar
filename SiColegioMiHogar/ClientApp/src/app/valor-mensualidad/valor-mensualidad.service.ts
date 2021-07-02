import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { IValorMensualidad } from './valor-mensualidad.component';

@Injectable({
  providedIn: 'root'
})
export class ValorMensualidadService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/ValorMensualidad";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getValorMensualidad(id: number): Observable<IValorMensualidad> {
    return this.http.get<IValorMensualidad>(this.apiURL + '/' + id);
  }
  getValorMensualidades(): Observable<IValorMensualidad[]> {
    return this.http.get<IValorMensualidad[]>(this.apiURL);
  }
  createValorMensualidad(valorMensualidad: IValorMensualidad): Observable<IValorMensualidad> {
    return this.http.post<IValorMensualidad>(this.apiURL, valorMensualidad);
  }

  updateValorMensualidad(valorMensualidad: IValorMensualidad): Observable<IValorMensualidad> {
    return this.http.put<IValorMensualidad>(this.apiURL + "/" + valorMensualidad.id, valorMensualidad);
  }
}
