import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INota, INotaConsult, IEstudianteNota, IPeriodoNota, MateriaNota} from './nota.component';
@Injectable({
  providedIn: 'root'
})
export class NotaService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Nota/Notas";
  apiURLCREATE = this.baseUrl + "api/Nota/CreateNota";
  apiURLEstudiantes = this.baseUrl + "api/Estudiante/Estudiantes";
  apiURLPeriodos = this.baseUrl + "api/Periodo/Periodos";
  apiURLMaterias = this.baseUrl + "api/Materia/Materias";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

  getNotas(): Observable<INotaConsult[]> {
    return this.http.get<INotaConsult[]>(this.apiURL);
  }

  getNota(id: number): Observable<INotaConsult> {
    return this.http.get<INotaConsult>(this.apiURL+id);
  }

  getEstudiantes(): Observable<IEstudianteNota[]> {
    return this.http.get<IEstudianteNota[]>(this.apiURLEstudiantes);
  }

  getPeriodos(): Observable<IPeriodoNota[]> {
    return this.http.get<IPeriodoNota[]>(this.apiURLPeriodos);
  }

  getMaterias(): Observable<MateriaNota[]> {
    return this.http.get<MateriaNota[]>(this.apiURLMaterias);
  }

  createNota(nota: INota): Observable<INota> {
    return this.http.post<INota>(this.apiURL, nota);
  }
}
