import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IMatricula, IMatricula2 } from './matricula.component';

@Injectable({
  providedIn: 'root'
})
export class MatriculaService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Matricula";
  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

  getMatriculas(): Observable<IMatricula[]> {
    return this.http.get<IMatricula[]>(this.apiURL);
  }

  getMatricula(idPreMatricula: number): Observable<IMatricula2> {
    return this.http.get<IMatricula2>(this.apiURL + '/' + idPreMatricula.toString());
  }

  createMatricula(idPreMatricula: number): Observable<number> {
    return this.http.post<number>(this.apiURL,idPreMatricula);
  }

  deleteMatricula(idMatricula: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idMatricula).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
