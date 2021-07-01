import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IAbono, IAbonoVista } from './abono.component';

@Injectable({
  providedIn: 'root'
})
export class AbonoService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Abono";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  getAbonos(): Observable<IAbonoVista[]> {
    return this.http.get<IAbonoVista[]>(this.apiURL);
  }

  getAbonosMensualidad(abono: number): Observable<IAbonoVista[]> {
    return this.http.get<IAbonoVista[]>(this.apiURL + '/GetAbonoMensualidad/' + abono);
  }


  getAbono(idAbono: number): Observable<IAbono> {
    return this.http.get<IAbono>(this.apiURL + '/' + idAbono);
  }

  createAbono(abono: IAbono): Observable<IAbono> {
    return this.http.post<IAbono>(this.apiURL, abono);
  }

  updateAbono(abono: IAbono): Observable<IAbono> {
    return this.http.put<IAbono>(this.apiURL + "/" + abono.id, abono);
  }

  AnularAbono(abono: IAbono): Observable<IAbono> {
    return this.http.put<IAbono>(this.apiURL + "/PutAnular/" + abono.id, abono)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })

      );
  }



}
