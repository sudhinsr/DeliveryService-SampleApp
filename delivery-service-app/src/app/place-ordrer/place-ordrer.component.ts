import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';
import { Customer } from '../interface/customer';
import { CustomerService } from '../service/customer.service';

@Component({
  selector: 'app-place-ordrer',
  templateUrl: './place-ordrer.component.html',
  styleUrls: ['./place-ordrer.component.css']
})
export class PlaceOrdrerComponent implements OnInit {

  customers: Customer[];

  constructor(private orderService: OrderService, private customerService: CustomerService) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe(data => {
    });
  }

}
