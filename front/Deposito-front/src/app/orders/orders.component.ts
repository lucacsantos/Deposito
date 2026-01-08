import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order-service/order.service';
import { Order } from '../models/Order';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
  imports: [CommonModule]
})
export class OrdersComponent implements OnInit {
  public orders : Order[] = [];
  public orderList: Order[] = [];

  private _filterList = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value : string) { 
    this._filterList = value;
    this.orderList = this.filterList ? this.filterOrder(this.filterList) : this.orders;
  }

  constructor(private orderService : OrderService) { }

  ngOnInit() {
    this.getOrders();
  }

  public filterOrder(filter: string): Order[]{
    filter = filter.toLocaleLowerCase();
    return this.orders;

  }
  public getOrders(): void {
     const oberserver = {
      next:(response : Order[]) => {
        this.orders = response;
        this.orderList = this.orders;
      },
      error: (error: any) => console.log(error)
     };
     this.orderService.getOrder().subscribe(oberserver);
  }
}
