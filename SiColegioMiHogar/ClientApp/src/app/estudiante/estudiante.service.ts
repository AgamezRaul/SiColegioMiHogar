import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEstudiante, IEstudiante2 } from './estudiante.component';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {
  apiURL = this.baseUrl + "api/Estudiante";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEstudiantes(): Observable<IEstudiante[]> {
    return this.http.get<IEstudiante[]>(this.apiURL);
  }
  getEstudiantesUsuarios(): Observable<IEstudiante2[]> {
    return this.http.get<IEstudiante2[]>(this.apiURL + '/GetEstudianteUsuarios');
  }
  GetEstudianteCurso(idMateria: number): Observable<IEstudiante[]> {
    return this.http.get<IEstudiante[]>(this.apiURL + '/GetEstudianteCurso/' + idMateria);
  }
}
