import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGrado } from './grado.component';

@Injectable({
  providedIn: 'root'
})
export class GradoService {

  apiURL = this.baseUrl + "api/Grado";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGrados(): Observable<IGrado[]> {
    return this.http.get<IGrado[]>(this.apiURL);
  }
  createGrado(grado: IGrado): Observable<IGrado> {
    return this.http.post<IGrado>(this.apiURL, grado);
  }
}
