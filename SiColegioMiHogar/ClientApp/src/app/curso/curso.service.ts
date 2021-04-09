import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICurso, ICurso2 } from './curso.component';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  apiURL = this.baseUrl + "api/Curso";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCursos(): Observable<ICurso2[]> {
    return this.http.get<ICurso2[]>(this.apiURL);
  }

  getCurso(id: number): Observable<ICurso> {
    return this.http.get<ICurso>(this.apiURL + '/' + id);
  }

  createCurso(curso: ICurso): Observable<ICurso> {
    return this.http.post<ICurso>(this.apiURL, curso);
  }
}
