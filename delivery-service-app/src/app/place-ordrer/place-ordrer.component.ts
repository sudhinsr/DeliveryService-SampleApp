import { Component, OnInit } from '@angular/core';
import { OrderService } from '../service/order.service';
import { Customer } from '../interface/customer';
import { CustomerService } from '../service/customer.service';
import { ProductService } from '../service/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../interface/product';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Order } from '../interface/order';

@Component({
  selector: 'app-place-ordrer',
  templateUrl: './place-ordrer.component.html',
  styleUrls: ['./place-ordrer.component.css']
})
export class PlaceOrdrerComponent implements OnInit {

  currentCustomerId: number;
  productId: number;
  product: Product;
  customer: Customer;
  orderForm: FormGroup;
  minDate: Date;
  estimatedPrice = 0;
  isWeekend = false;

  constructor(private orderService: OrderService,
              private customerService: CustomerService,
              private productService: ProductService,
              private route: ActivatedRoute,
              private router: Router ) { }

  ngOnInit() {
    this.minDate = new Date();
    this.route.paramMap.subscribe(param => {
      this.currentCustomerId = +param.get('customerId');
      this.productId = +param.get('productId');
    });

    this.createOrderForm();
  }

  createOrderForm() {
    this.orderForm = new FormGroup({
      DeliveryDate: new FormControl('', [Validators.required]),
      Coupon: new FormControl(''),
      Distance: new FormControl('', [Validators.required, Validators.pattern('[0-9]*')]),
      NoOfFloors: new FormControl('', [Validators.required, Validators.pattern('[0-9]*')]),
    });

    this.orderForm.valueChanges.subscribe(() => {
      if (this.orderForm.valid) {
        const estimation = this.buildOrder();
        this.orderService.getPriceEstimation(estimation).subscribe(data => {
          this.estimatedPrice = data.Price;
        });
      }
    });

    this.orderForm.valueChanges.subscribe(() => {
      if (this.orderForm.controls.DeliveryDate.valid) {
        const day = this.orderForm.controls.DeliveryDate.value.getDay();
        this.isWeekend = (day === 6 || day === 0);
      }
    });
  }

  buildOrder()  {
    const order: Order = {
      CustomerId: this.currentCustomerId,
      Coupon: this.orderForm.controls.Coupon.value,
      DeliveryDate: this.orderForm.controls.DeliveryDate.value.toDateString(),
      Distance: this.orderForm.controls.Distance.value,
      NoOfFloors: this.orderForm.controls.NoOfFloors.value,
      OrderId: 0,
      ProductId: this.productId,
      Price: this.estimatedPrice
    };
    return order;
  }

  placeOrder() {
    const order = this.buildOrder();
    this.orderService.placeOrder(order).subscribe(data =>{
      this.router.navigate(['chose-customer']);
    });
  }
}
