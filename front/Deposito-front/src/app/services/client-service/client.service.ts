import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../../models/Client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

constructor(private http: HttpClient) { }

public getClients(): Observable<Client[]>{
  return this.http.get<Client[]>('https://localhost:7036/api/client');
}



}
