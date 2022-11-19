import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _httpClient: HttpClient) { }

  get(): Observable<any> {
    return this._httpClient.get(environment.apiUrl);
  }

  evolve(name: string): Observable<any> {
    return this._httpClient.post(`${environment.apiUrl}/${name}/action`, {});
  }
  delete(id: number): Observable<any> {
    return this._httpClient.delete(`${environment.apiUrl}/${id}`);
  }
}
