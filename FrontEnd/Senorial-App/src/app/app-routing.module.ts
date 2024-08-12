import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './guard/auth.guard';
import { NotFoundError } from 'rxjs';
import { NotFoundPageComponent } from './ecommerce/pages/not-found-page/not-found-page.component';

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
    path: 'notfound',
    component: NotFoundPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
