import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPrematricula } from '../responsable/responsable.component';

@Injectable({
  providedIn: 'root'
})
export class PreMatriculaService {

  apiURL = this.baseUrl + "api/Prematricula";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPrematriculas(): Observable<IPrematricula[]> {
    return this.http.get<IPrematricula[]>(this.apiURL);
  }

  getPrematricula(id: number): Observable<IPrematricula> {
    return this.http.get<IPrematricula>(this.apiURL + '/' + id);
  }

  createPrematricula(prematricula: IPrematricula): Observable<IPrematricula> {
    return this.http.post<IPrematricula>(this.apiURL, prematricula);
  }

  updatePrematricula(prematricula: IPrematricula): Observable<IPrematricula> {
    return this.http.put<IPrematricula>(this.apiURL + "/" + prematricula.iAcudiente.ideResponsableAcudiente, prematricula);
  }

  deletePrematricula(id: number): Observable<IPrematricula> {
    return this.http.put<IPrematricula>(this.apiURL + "/DeletePrematricula" + "/" + id.toString(), id);
  }
}

