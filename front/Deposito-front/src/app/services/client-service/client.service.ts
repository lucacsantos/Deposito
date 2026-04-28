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

public create(client: Client): Observable<Client>{
  return this.http.post<Client>('https://localhost:7036/api/client', client);
}

public delete(id: string) {
  return this.http.delete<void>(`https://localhost:7036/api/client/${id}`)
}

public getById(id: string): Observable<Client> {
  return this.http.get<Client>(`https://localhost:7036/api/client/${id}`)
}


}
