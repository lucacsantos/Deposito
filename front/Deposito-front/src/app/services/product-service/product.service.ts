import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../models/Product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

constructor(private http: HttpClient) { }

 getProducts() : Observable<any[]> {
  return this.http.get<Product[]>('https://localhost:7036/api/product');
 }
}
