import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable,Subject } from 'rxjs';
import { IDocente, IDocente2 } from './docente.component';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class DocenteService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Docente";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get refresh$() {
    return this._refresh$;
  }
  getDocentes(): Observable<IDocente2[]> {
    return this.http.get<IDocente2[]>(this.apiURL);
  }


  getDocente(id: number): Observable<IDocente> {
    return this.http.get<IDocente>(this.apiURL + '/' + id);
  }

  createDocente(docente: IDocente): Observable<IDocente> {
    return this.http.post<IDocente>(this.apiURL, docente);
  }
  updateDocente(docente: IDocente): Observable<IDocente> {
    return this.http.put<IDocente>(this.apiURL + "/" + docente.id, docente);
  }
  deleteDocente(idDocente: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idDocente)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })

      );
  }


}
