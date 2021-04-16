import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMateria, IMateria2 } from './gestion-de-materias.component';

@Injectable({
  providedIn: 'root'
})
export class GestionDeMateriasService {

  apiURL = this.baseUrl + "api/Materia";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getMaterias(): Observable<IMateria[]> {
    return this.http.get<IMateria[]>(this.apiURL);
  }

  getMateria(materia: number): Observable<IMateria> {
    return this.http.get<IMateria>(this.apiURL + '/' + materia);
  }
  
  createMateria(materia: IMateria): Observable<IMateria> {
    return this.http.post<IMateria>(this.apiURL, materia);
  }

  updateMateria(materia: IMateria): Observable<IMateria> {
    return this.http.put<IMateria>(this.apiURL + "/" + materia.IdCurso, materia);
  }

  deleteMateria(materia: IMateria): Observable<IMateria> {
    return this.http.put<IMateria>(this.apiURL + "/DeleteMateria" + "/" + materia.IdCurso.toString(), materia);
  }
}
