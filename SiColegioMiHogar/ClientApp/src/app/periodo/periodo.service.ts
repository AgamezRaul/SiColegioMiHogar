import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IPeriodo } from './periodo.component';

@Injectable({
  providedIn: 'root'
})
export class PeriodoService {

  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Periodo/Periodos";
  apiURLCREATE = this.baseUrl + "api/Periodo/CreatePeriodo";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  
  getPeriodos(): Observable<IPeriodo[]> {
    return this.http.get<IPeriodo[]>(this.apiURL);
  }

  getPeriodo(id: number): Observable<IPeriodo> {
    return this.http.get<IPeriodo>(this.apiURL);
  }

  createPeriodo(periodo: IPeriodo): Observable<IPeriodo> {
    console.log(periodo);
    return this.http.post<IPeriodo>(this.apiURLCREATE, periodo);
  }
}
