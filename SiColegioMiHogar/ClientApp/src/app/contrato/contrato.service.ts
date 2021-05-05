import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IContrato } from './contrato.component';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {
  apiURL = this.baseUrl + "api/Contrato";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  updateContrato(contrato: IContrato): Observable<IContrato> {
    return this.http.put<IContrato>(this.apiURL + "/" + contrato.idDocente, contrato);
  }
}
