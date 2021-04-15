import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICurso, ICurso2 } from './curso.component';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Curso";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  getCursos(): Observable<ICurso2[]> {
    return this.http.get<ICurso2[]>(this.apiURL);
  }

  getCursoDocente(id: number): Observable<ICurso2[]> {
    return this.http.get<ICurso2[]>(this.apiURL + '/GetCursoDocente/' + id);
  }


  getCurso(idCurso: number): Observable<ICurso> {
    return this.http.get<ICurso>(this.apiURL + '/' + idCurso);
  }

  createCurso(curso: ICurso): Observable<ICurso> {
    return this.http.post<ICurso>(this.apiURL, curso);
  }

  updateCurso(curso: ICurso): Observable<ICurso> {
    return this.http.put<ICurso>(this.apiURL + "/" + curso.id, curso);
  }

  deleteCurso(idCurso: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idCurso)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })

      );
  }
}
