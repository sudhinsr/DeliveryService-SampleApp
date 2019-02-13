import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../interface/product';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  baseUrl: string = 'http://localhost:5152/';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<Product[]>(this.baseUrl + "product");
  }
}
