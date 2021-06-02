import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICurso } from '../curso/curso.component';
import { IEstudiante } from '../estudiante/estudiante.component';
import { IEstudianteCurso } from './estudiante-curso.component';

@Injectable({
  providedIn: 'root'
})
export class EstudianteCursoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/EstudianteCurso";
  get refresh$() {
    return this._refresh$;
  }

  getEstudiantesCurso(): Observable<IEstudianteCurso[]> {
    return this.http.get<IEstudianteCurso[]>(this.apiURL);
  }

  getEstudianteCurso(id: number): Observable<IEstudianteCurso> {
    return this.http.get<IEstudianteCurso>(this.apiURL + '/' + id);
  }

  getEstudianteGrado(grado: string): Observable<IEstudiante[]> {
    return this.http.get<IEstudiante[]>(this.apiURL + '/EstudianteGrado/' + grado);
  }

  getCursoGrado(grado: string): Observable<ICurso[]> {
    return this.http.get<ICurso[]>(this.apiURL + '/CursoGrado/' + grado);
  }

  createEstudianteCurso(estudiantesCurso: IEstudianteCurso[]): Observable<IEstudianteCurso[]> {
    return this.http.post<IEstudianteCurso[]>(this.apiURL, estudiantesCurso).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateEstudianteCurso(actividad: IEstudianteCurso): Observable<IEstudianteCurso> {
    return this.http.put<IEstudianteCurso>(this.apiURL, actividad).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  deleteEstudianteCurso(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
