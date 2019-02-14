import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Order } from '../interface/order';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl: string = environment.apiUrl + 'order/';

  constructor(private http: HttpClient) { }

  getOrders() {
    return this.http.get<Order[]>(this.baseUrl);
  }

  placeOrder(order: Order) {
    return this.http.post<Order>(this.baseUrl, order);
  }

  getPriceEstimation(order: Order) {
    return this.http.post<Order>(this.baseUrl + 'price-estimation', order);
  }
}
