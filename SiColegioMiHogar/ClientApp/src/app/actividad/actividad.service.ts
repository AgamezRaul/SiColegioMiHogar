import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IActividad } from './actividad.component';

@Injectable({
  providedIn: 'root'
})
export class ActividadService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Actividad";
  get refresh$() {
    return this._refresh$;
  }

  getActividades(): Observable<IActividad[]> {
    return this.http.get<IActividad[]>(this.apiURL);
  }

  getActividad(id: number): Observable<IActividad> {
    return this.http.get<IActividad>(this.apiURL + '/' + id);
  }

  createActividad(actividad: IActividad): Observable<IActividad> {
    return this.http.post<IActividad>(this.apiURL, actividad).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateActividad(actividad: IActividad): Observable<IActividad> {
    return this.http.put<IActividad>(this.apiURL, actividad).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  deleteActividad(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  getActividadMateria(id: number): Observable<IActividad[]> {
    return this.http.get<IActividad[]>(this.apiURL + "/GetActividadesMateria?idMateria=" + id);
  } 

}
