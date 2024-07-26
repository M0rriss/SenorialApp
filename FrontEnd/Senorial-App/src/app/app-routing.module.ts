import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from '@pages-ecommerce/home-page/home-page.component';
import { LocalComponent } from './dashboard/pages/local/local.component';
import { MesaDetailComponent } from './dashboard/pages/mesa-detail/mesa-detail.component';

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
