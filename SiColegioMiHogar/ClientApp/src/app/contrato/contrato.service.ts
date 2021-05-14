import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IContrato, IContratos } from './contrato.component';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {
  apiURL = this.baseUrl + "api/Contrato";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getContratos(): Observable<IContratos[]> {
    return this.http.get<IContratos[]>(this.apiURL);
  }

  createContrato(contrato: IContrato): Observable<IContrato> {
    return this.http.post<IContrato>(this.apiURL, contrato);
  }

  updateContrato(contrato: IContrato): Observable<IContrato> {
    return this.http.put<IContrato>(this.apiURL + "/" + contrato.idDocente, contrato);
  }

  getContrato(idDocente: number): Observable<IContrato> {
    return this.http.get<IContrato>(this.apiURL + '/' + idDocente);
    }

    deleteContrato(idDocente: number): Observable<IContrato> {
        return this.http.delete<IContrato>(this.apiURL + '/' + idDocente);
    }

}
