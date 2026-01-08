import { Component, OnInit } from '@angular/core';
import { CommonModule,  } from "@angular/common";

import { Product } from '../models/Product';
import { ProductService } from '../services/product-service/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  imports: [CommonModule],
 
})

export class ProductComponent implements OnInit {
 public products : Product[] = [];
 public productList: Product[] = [];

 private _filterList : string = '';


 public get filterList(): string{
  return this._filterList;
 }

 public set filterList(value : string) {
  this._filterList =  value;
  this.productList = this.filterList ? this.filterProduct(this.filterList) : this.products;
 }

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.getProducts();
  }

  public filterProduct(filter: string): Product[]{
    filter = filter.toLocaleLowerCase();
    return this.products.filter((
      product: {name: string}) => product.name.toLocaleLowerCase().indexOf(filter)  !== -1 )
  }

  public getProducts(): void {
    const oberserver = {
      next:(response : Product[]) => {
        this.products = response;
        this.productList = this.products;
      },
      error: (error: any) => console.log(error)
    };
    this.service.getProducts().subscribe(oberserver);

    }

  }
