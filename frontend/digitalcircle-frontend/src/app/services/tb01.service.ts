import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TB01 } from '../models/tb01.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class Tb01Service {
  baseUrl: string = environment.apiUrl + '/tb01';

  constructor(private htpp: HttpClient) {}

  getAll(): Observable<TB01[]> {
    return this.htpp.get<TB01[]>(this.baseUrl);
  }

  create(tb01: TB01): Observable<any> {
    return this.htpp.post(`${this.baseUrl}/create`, tb01);
  }

  delete(tb01: TB01): Observable<any> {
    return this.htpp.post(`${this.baseUrl}/delete`, tb01);
  }

  update(tb01: TB01): Observable<any> {
    return this.htpp.post(`${this.baseUrl}/update`, tb01);
  }
}