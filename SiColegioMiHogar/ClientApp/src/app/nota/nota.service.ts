import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INota, INotaConsult, IEstudianteNota, IPeriodoNota, MateriaNota} from './nota.component';
@Injectable({
  providedIn: 'root'
})
export class NotaService {
  apiURL = this.baseUrl + "api/Nota";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getNotas(): Observable<INotaConsult[]> {
    return this.http.get<INotaConsult[]>(this.apiURL);
  }

  getNota(id: number): Observable<INotaConsult> {
    return this.http.get<INotaConsult>(this.apiURL+id);
  }

  createNota(nota: INota): Observable<INota> {
    return this.http.post<INota>(this.apiURL, nota);
  }
}
