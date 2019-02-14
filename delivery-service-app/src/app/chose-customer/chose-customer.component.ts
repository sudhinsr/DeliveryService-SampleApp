import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../service/customer.service';
import { Customer } from '../interface/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chose-customer',
  templateUrl: './chose-customer.component.html',
  styleUrls: ['./chose-customer.component.css']
})
export class ChoseCustomerComponent implements OnInit {

  customers: Customer[];
  selectedCustomerId = 0;

  constructor(private customerService: CustomerService, private router: Router) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(data =>{
      this.customers = data;
    });
  }

  userSelected(event){
    this.router.navigate(['/list-product', this.selectedCustomerId]);
  }
}
