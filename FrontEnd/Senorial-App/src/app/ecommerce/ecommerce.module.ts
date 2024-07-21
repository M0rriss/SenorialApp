import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EcommerceRoutingModule } from '@ecommerce/ecommerce-routing.module';

import { BannerEcommerceComponent } from '@components-ecommerce/banner-ecommerce/banner-ecommerce.component';
import { CategoriesBarComponent } from '@components-ecommerce/categories-bar/categories-bar.component';
import { HomePageComponent } from '@pages-ecommerce/home-page/home-page.component';
import { NavBarComponent } from '@components-ecommerce/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CardProductComponent } from './components/card-product/card-product.component';
import { CardCategoryComponent } from './components/card-category/card-category.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { InternalServerErrorComponent } from './pages/internal-server-error/internal-server-error.component';
import { LocalesSenorialComponent } from './pages/locales-senorial/locales-senorial.component';
import { StaffPersonalComponent } from './components/staff-personal/staff-personal.component';


@NgModule({
  declarations: [
  
    HomePageComponent,
    NavBarComponent,
    BannerEcommerceComponent,
    CategoriesBarComponent,
    FooterComponent,
    CardProductComponent,
    CardCategoryComponent,
    ShoppingCartComponent,
    NotFoundPageComponent,
    InternalServerErrorComponent,
    LocalesSenorialComponent,
    StaffPersonalComponent
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
