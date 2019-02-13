import { Component, OnInit } from '@angular/core';
import { Product } from '../interface/product';
import { ClientService } from '../service/client.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  products : Product[];
  constructor(private clientService: ClientService) { }

  ngOnInit() {
    this.clientService.getUsers()
      .subscribe( data => {
        this.products = data;
      });
  }
}
