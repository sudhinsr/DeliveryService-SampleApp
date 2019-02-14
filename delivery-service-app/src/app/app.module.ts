import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListProductComponent } from './list-product/list-product.component';
import { ProductService } from './service/product.service';
import { HttpClientModule } from '@angular/common/http';
import { PlaceOrdrerComponent } from './place-ordrer/place-ordrer.component';
import { OrderService } from './service/order.service';
import { CustomerService } from './service/customer.service';

@NgModule({
  declarations: [
    AppComponent,
    ListProductComponent,
    PlaceOrdrerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ProductService, OrderService, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
