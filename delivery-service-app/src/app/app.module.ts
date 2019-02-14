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
import { ChoseCustomerComponent } from './chose-customer/chose-customer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppMaterialModule } from './material-module';

@NgModule({
  declarations: [
    AppComponent,
    ListProductComponent,
    PlaceOrdrerComponent,
    ChoseCustomerComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppMaterialModule
  ],
  providers: [ProductService, OrderService, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
