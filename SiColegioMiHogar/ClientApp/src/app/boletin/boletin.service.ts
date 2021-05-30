import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IBoletin } from './boletin.component';


@Injectable({
  providedIn: 'root'
})
export class BoletinService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Boletin";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get refresh$() {
    return this._refresh$;
  }
  getBoletines(): Observable<IBoletin[]> {
    return this.http.get<IBoletin[]>(this.apiURL);
  }
  createBoletin(boletin: IBoletin): Observable<IBoletin> {
    return this.http.post<IBoletin>(this.apiURL, boletin);
  }
  updateBoletin(boletin: IBoletin): Observable<IBoletin> {
    return this.http.put<IBoletin>(this.apiURL + "/" + boletin.id, boletin);
  }
  deleteBoletin(idBoletin: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + idBoletin)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })
      );
  }
}
