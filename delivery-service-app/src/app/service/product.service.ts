import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../interface/product';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl: string = environment.apiUrl + 'product/';

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<Product[]>(this.baseUrl);
  }

  getProduct(productId: number) {
    return this.http.get<Product>(this.baseUrl + productId);
  }
}
