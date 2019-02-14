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
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule, MatOptionModule, MatFormFieldModule, MatButtonModule,
  MatTableModule, MatHeaderCell, MatDialogModule } from '@angular/material';


@NgModule({
  declarations: [
    AppComponent,
    ListProductComponent,
    PlaceOrdrerComponent,
    ChoseCustomerComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule
  ],
  providers: [ProductService, OrderService, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
