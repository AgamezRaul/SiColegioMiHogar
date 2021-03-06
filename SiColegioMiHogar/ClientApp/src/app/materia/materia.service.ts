import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMateria } from './materia.component';

@Injectable({
  providedIn: 'root'
})
export class MateriaService {

  apiURL = this.baseUrl + "api/Materia";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getMaterias(): Observable<IMateria[]> {
    return this.http.get<IMateria[]>(this.apiURL);
  }

  getMateria(id: number): Observable<IMateria> {
    return this.http.get<IMateria>(this.apiURL + '/' + id);
  }

  GetMateriaDocente(correo: string): Observable<IMateria[]> {
    return this.http.get<IMateria[]>(this.apiURL + '/materiaDocente/' + correo);
  }

  GetMateriasEstudiante(idEstudiante: number): Observable<IMateria[]> {
    return this.http.get<IMateria[]>(this.apiURL + '/materiasEstudiante/' + idEstudiante);
  }

  createMateria(materia: IMateria): Observable<IMateria> {
    return this.http.post<IMateria>(this.apiURL, materia);
  }

  updateMateria(materia: IMateria): Observable<IMateria> {
    return this.http.put<IMateria>(this.apiURL + "/" + materia.id, materia);
  }

  deleteMateria(id: number): Observable<IMateria> {
    return this.http.delete<IMateria> (this.apiURL + "/" + id);
  }
}
