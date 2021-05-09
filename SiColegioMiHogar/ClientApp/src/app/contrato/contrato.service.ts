import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { IContrato } from './contrato.component';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {
  
  private _refresh$ = new Subject<void>();

  apiURL = this.baseUrl + "api/Contrato";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  
  updateContrato(contrato: IContrato): Observable<IContrato> {
    return this.http.put<IContrato>(this.apiURL + "/" + contrato.idDocente, contrato);
  }

  getContrato(id: number): Observable<IContrato> {
    return this.http.get<IContrato>(this.apiURL + '/GetContrato?id='+id);
  }

  getContratos(): Observable<IContrato[]> {
    return this.http.get<IContrato[]>(this.apiURL+'/getContratos');
  }
}
