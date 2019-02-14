import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Customer } from '../interface/customer';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl: string = environment.apiUrl + 'customer/';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get<Customer[]>(this.baseUrl);
  }

  getCustomer(customerId: number)  {
    return this.http.get<Customer>(this.baseUrl + customerId);
  }
}
