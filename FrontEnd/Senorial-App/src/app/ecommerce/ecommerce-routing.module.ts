import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { UserAccountComponent } from './pages/user-account/user-account.component';
import { LocalesSenorialComponent } from './pages/locales-senorial/locales-senorial.component';
import { StaffPersonalComponent } from './components/staff-personal/staff-personal.component';
import { AddItemToCheckoutComponent } from './pages/add-item-to-checkout/add-item-to-checkout.component';
import { StorePickUpComponent } from './pages/store-pick-up/store-pick-up.component';
import { CheckOutComponent } from './pages/check-out/check-out.component';
import { SelectPaymentComponent } from './pages/select-payment/select-payment.component';
import { NotFoundError } from 'rxjs';

const routes: Routes = [

  {
    path      :'',
    component : HomePageComponent
  },
  {
    path: 'notfound',
    component: NotFoundError
  },
  {
    path      :'userAcount',
    component : UserAccountComponent
  },
  {
    path      :'locales',
    component : LocalesSenorialComponent
  },
  {
    path      :'personal',
    component : StaffPersonalComponent
  },
  {
    path      :'menu/menu',
    component : AddItemToCheckoutComponent
  },
  {
    path      :'store-pickup',
    component : StorePickUpComponent
  },
  {
    path      :'checkout',
    component : CheckOutComponent
  },
  {
    path      :'select-payment',
    component : SelectPaymentComponent
  },
  {
    path      :'e-commerce',
    loadChildren: () => import('@app/ecommerce/ecommerce.module').then(m => m.EcommerceModule)
  },
  {
    path      :'**',
    pathMatch: 'full',
    redirectTo:'notfound'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [
    RouterModule,
            ]
})
export class EcommerceRoutingModule { }
