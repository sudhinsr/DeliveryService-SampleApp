import { Component, OnInit } from '@angular/core';
import { Product } from '../interface/product';
import { ProductService } from '../service/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  products: Product[];
  displayedColumns: string[] = ['ProductId', 'ProductName', 'BasePrice', 'Action'];
  currentCustomerId: number;

  constructor(private productService: ProductService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.productService.getProducts()
      .subscribe(data => {
        this.products = data;
      });

    this.route.paramMap.subscribe(param => {
      this.currentCustomerId = +param.get('customerId');
    });
  }

  productSelected(event, productId) {
    this.router.navigate(['place-order', this.currentCustomerId, productId]);
  }
}
