import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../../models/Order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

constructor(private http : HttpClient) { }

public getOrder(): Observable<Order[]> {
  return this.http.get<Order[]>('https://localhost:7036/api/order')
}

}
