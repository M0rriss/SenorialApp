import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from '@pages-ecommerce/home-page/home-page.component';
import { LocalComponent } from './dashboard/pages/local/local.component';
import { MesaDetailComponent } from './dashboard/pages/mesa-detail/mesa-detail.component';
import { InvoiceTypeComponent } from './dashboard/pages/invoice-type/invoice-type.component';
import { OrdersComponent } from './dashboard/pages/orders/orders.component';

const routes: Routes = [
  {
    path      :'home',
    component : HomePageComponent
  },
  {
    path      :'dashboard',
    component : LocalComponent
  },
  {
    path      :'mesadetail',
    component : MesaDetailComponent
  },
  {
    path      :'invoice',
    component : InvoiceTypeComponent
  },
  {
    path      :'pedidos',
    component : OrdersComponent
  },
  // {
  //   path      :'**',
  //   redirectTo:'home'
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
