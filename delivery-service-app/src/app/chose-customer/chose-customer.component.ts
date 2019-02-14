import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../service/customer.service';
import { Customer } from '../interface/customer';

@Component({
  selector: 'app-chose-customer',
  templateUrl: './chose-customer.component.html',
  styleUrls: ['./chose-customer.component.css']
})
export class ChoseCustomerComponent implements OnInit {

  customers: Customer[];
  selectedCustomerId: number;

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(data =>{
      this.customers = data;
    });
  }

}
