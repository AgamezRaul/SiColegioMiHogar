import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INotaPeriodo, INotaPeriodo2 } from './nota-periodo.component';


@Injectable({
  providedIn: 'root'
})
export class NotaPeriodoService {

  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/NotaPeriodo";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  getNotasPeriodos(): Observable<INotaPeriodo2[]> {
    return this.http.get<INotaPeriodo2[]>(this.apiURL);
  }

  getNotaPeriodoMateriaPeriodo(id: number): Observable<INotaPeriodo2[]> {
    return this.http.get<INotaPeriodo2[]>(this.apiURL + '/GetNotaPeriodoMateriaPeriodo/' + id);
  }


  getNotaPeriodo(idNotaPeriodo: number): Observable<INotaPeriodo> {
    return this.http.get<INotaPeriodo>(this.apiURL + '/' + idNotaPeriodo);
  }

  createNotaPeriodo(notaPeriodo: INotaPeriodo): Observable<INotaPeriodo> {
    return this.http.post<INotaPeriodo>(this.apiURL, notaPeriodo);
  }

  updateNotaPeriodo(notaPeriodo: INotaPeriodo): Observable<INotaPeriodo> {
    return this.http.put<INotaPeriodo>(this.apiURL + "/" + notaPeriodo.id, notaPeriodo);
  }

  deleteNotaPeriodo(idNotaPeriodo: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idNotaPeriodo)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })

      );
  }
}
