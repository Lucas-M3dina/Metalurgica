import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Token, Usuario } from '../interface/interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private readonly API = 'https://localhost:7206/api/'

  constructor(private http : HttpClient) { }

  Login(email : string, senha : string) : Observable<Token>{
    const user = {email, senha}

    return this.http.post<Token>(this.API + "login", user)
  }

  GetMe(): Observable<Usuario>{
    const headers = new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem("token")}`);
    return this.http.get<Usuario>(`${this.API}usuarios/me`, { headers });
  }



}
