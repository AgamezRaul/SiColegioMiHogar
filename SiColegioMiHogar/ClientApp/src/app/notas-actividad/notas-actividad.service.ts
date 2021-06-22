import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INotaConsult} from '../nota/nota.component';

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

  getNotasActividad(id: number): Observable<INotaConsult[]> {
    return this.http.get<INotaConsult[]>(this.apiURL+'/notas-actividad/'+id);
  }

}
