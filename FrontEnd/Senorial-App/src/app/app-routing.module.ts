import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './guard/auth.guard';

const routes: Routes = [
  {
    path      :'e-commerce',
    loadChildren: () => import('@app/ecommerce/ecommerce.module').then(m => m.EcommerceModule)
  },
  {
    path      :'dash',
    loadChildren: () => import('@app/dashboard/dashboard.module').then(m => m.DashboardModule),
  },

  {
    path      :'**',
    redirectTo:'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
