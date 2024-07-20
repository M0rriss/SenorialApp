import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EcommerceRoutingModule } from '@ecommerce/ecommerce-routing.module';

import { BannerEcommerceComponent } from '@components-ecommerce/banner-ecommerce/banner-ecommerce.component';
import { CategoriesBarComponent } from '@components-ecommerce/categories-bar/categories-bar.component';
import { HomePageComponent } from '@pages-ecommerce/home-page/home-page.component';
import { NavBarComponent } from '@components-ecommerce/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CardProductComponent } from './components/card-product/card-product.component';


@NgModule({
  declarations: [
  
    HomePageComponent,
    NavBarComponent,
    BannerEcommerceComponent,
    CategoriesBarComponent,
    FooterComponent,
    CardProductComponent
  ],
  imports: [
    CommonModule,
    EcommerceRoutingModule
  ],
  exports: [ 
    NavBarComponent,
    BannerEcommerceComponent,
    CategoriesBarComponent
  ]
})
export class EcommerceModule { }
