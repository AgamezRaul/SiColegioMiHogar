import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IPrematricula, IPrematricula2 } from './pre-matricula.component';

@Injectable({
  providedIn: 'root'
})
export class PreMatriculaService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Prematricula";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

  getPrematriculas(): Observable<IPrematricula2[]> {
    return this.http.get<IPrematricula2[]>(this.apiURL);
  }

  getPrematricula(id: number): Observable<IPrematricula> {
    return this.http.get<IPrematricula>(this.apiURL + '/' + id);
  }

  createPrematricula(prematricula: IPrematricula): Observable<IPrematricula> {
    return this.http.post<IPrematricula>(this.apiURL, prematricula);
  }

  updatePreMatricula(prematricula: IPrematricula): Observable<IPrematricula> {
    return this.http.put<IPrematricula>(this.apiURL + "/" + prematricula.id.toString(), prematricula);
  }

  deletePreMatricula(idUsuario: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idUsuario).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}

