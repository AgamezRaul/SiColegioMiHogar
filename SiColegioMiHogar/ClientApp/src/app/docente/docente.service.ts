import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDocente, IDocente2 } from './docente.component';

@Injectable({
  providedIn: 'root'
})
export class DocenteService {

  apiURL = this.baseUrl + "api/Docente";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDocentes(): Observable<IDocente2[]> {
    return this.http.get<IDocente2[]>(this.apiURL);
  }

  getDocente(id: number): Observable<IDocente> {
    return this.http.get<IDocente>(this.apiURL + '/' + id);
  }

  createDocente(docente: IDocente): Observable<IDocente> {
    return this.http.post<IDocente>(this.apiURL, docente);
  }
}
