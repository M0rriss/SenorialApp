import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EcommerceModule } from '@app/ecommerce/ecommerce.module';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [
    RouterModule,
            ]
})
export class EcommerceRoutingModule { }
