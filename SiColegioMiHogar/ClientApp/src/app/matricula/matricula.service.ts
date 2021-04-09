import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMatricula, IMatricula2 } from './matricula.component';

@Injectable({
  providedIn: 'root'
})
export class MatriculaService {
  apiURL = this.baseUrl + "api/Matricula";
  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  getMatriculas(): Observable<IMatricula[]> {
    return this.http.get<IMatricula[]>(this.apiURL);
  }

  getMatricula(idPreMatricula: number): Observable<IMatricula2> {
    return this.http.get<IMatricula2>(this.apiURL + '/' + idPreMatricula.toString());
  }

  createMatricula(idPreMatricula: number): Observable<number> {
    return this.http.post<number>(this.apiURL, idPreMatricula);
  }
}
