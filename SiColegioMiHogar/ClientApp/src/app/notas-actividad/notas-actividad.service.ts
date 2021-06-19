import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INota} from '../nota/nota.component';

@Injectable({
  providedIn: 'root'
})

export class NotasActividadService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Nota";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

  getNotasActividad(id: number): Observable<INota[]> {
    return this.http.get<INota[]>(this.apiURL+'/notas-actividad/'+id);
  }

}
