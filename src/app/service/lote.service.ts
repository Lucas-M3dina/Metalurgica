import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoteService {

  private readonly API = 'https://localhost:7206/api/'

  constructor(private http : HttpClient) { }

  
}
