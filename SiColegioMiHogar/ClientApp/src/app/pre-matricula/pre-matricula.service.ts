import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPrematricula, IPrematricula2 } from './form-pre-matricula/form-pre-matricula.component';

@Injectable({
  providedIn: 'root'
})
export class PreMatriculaService {

  apiURL = this.baseUrl + "api/Prematricula";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPrematriculas(): Observable<IPrematricula[]> {
    return this.http.get<IPrematricula[]>(this.apiURL);
  }
  tablaPrematricula(): Observable<any[]> {
    return this.http.get<any[]>(this.apiURL + "/tablaPrematricula");
  }

  getPrematricula(id: number): Observable<IPrematricula> {
    return this.http.get<IPrematricula>(this.apiURL + '/' + id);
  }

  createPrematricula(prematricula: IPrematricula): Observable<IPrematricula> {
    return this.http.post<IPrematricula>(this.apiURL, prematricula);
  }
}

