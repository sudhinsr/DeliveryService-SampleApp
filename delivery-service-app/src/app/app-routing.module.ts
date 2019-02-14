import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductComponent } from './list-product/list-product.component';
import { PlaceOrdrerComponent } from './place-ordrer/place-ordrer.component';
import { ChoseCustomerComponent } from './chose-customer/chose-customer.component';

const routes: Routes = [
  { path: '', redirectTo: 'chose-customer', pathMatch: 'full' },
  { path: 'chose-customer', component: ChoseCustomerComponent },
  { path: 'list-product/:customerId', component: ListProductComponent },
  { path: 'place-order/:customerId/:productId', component: PlaceOrdrerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
