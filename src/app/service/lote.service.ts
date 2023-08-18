import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lote } from '../interface/interfaces';

@Injectable({
  providedIn: 'root'
})
export class LoteService {

  private readonly API = 'https://localhost:7206/api/'

  constructor(private http : HttpClient) { }


  // CRIAR INTERFACE E TIRAR RETORNO ANY
  ListarLote(): Observable<Lote[]>{
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`);
    return this.http.get<Lote[]>(`${this.API}lote`, { headers });
  }

  GetLote(id : number): Observable<Lote>{
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`);
    return this.http.get<Lote>(`${this.API}lote/${id}`, { headers });
  }
}
