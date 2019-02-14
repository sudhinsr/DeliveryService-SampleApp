import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductComponent } from './list-product/list-product.component';
import { PlaceOrdrerComponent } from './place-ordrer/place-ordrer.component';
import { ChoseCustomerComponent } from './chose-customer/chose-customer.component';

const routes: Routes = [
  { path: '', redirectTo: 'chose-customer', pathMatch: 'full' },
  { path: 'list-product', component: ListProductComponent },
  { path: 'place-order', component: PlaceOrdrerComponent },
  { path: 'chose-customer', component: ChoseCustomerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
