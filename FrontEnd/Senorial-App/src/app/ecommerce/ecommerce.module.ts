import { NgModule }     from '@angular/core';
import { CommonModule } from '@angular/common';

import { EcommerceRoutingModule } from '@ecommerce/ecommerce-routing.module';

import { BannerEcommerceComponent }     from '@components-ecommerce/banner-ecommerce/banner-ecommerce.component';
import { CardCategoryComponent }        from '@components-ecommerce/card-category/card-category.component';
import { CardProductComponent }         from '@components-ecommerce/card-product/card-product.component';
import { CategoriesBarComponent }       from '@components-ecommerce/categories-bar/categories-bar.component';
import { FooterComponent }              from '@components-ecommerce/footer/footer.component';
import { HomePageComponent }            from '@pages-ecommerce/home-page/home-page.component';
import { IniciarSesionComponent }       from '@components-ecommerce/iniciar-sesion/iniciar-sesion.component';
import { InternalServerErrorComponent } from '@pages-ecommerce/internal-server-error/internal-server-error.component';
import { LocalesSenorialComponent }     from '@pages-ecommerce/locales-senorial/locales-senorial.component';
import { NavBarComponent }              from '@components-ecommerce/nav-bar/nav-bar.component';
import { NotFoundPageComponent }        from '@pages-ecommerce/not-found-page/not-found-page.component';
import { ShoppingCartComponent }        from '@components-ecommerce/shopping-cart/shopping-cart.component';
import { StaffPersonalComponent }       from '@components-ecommerce/staff-personal/staff-personal.component';
import { MenuListEcommerceComponent } from './components/menu-list-ecommerce/menu-list-ecommerce.component';
import { UserAccountComponent } from './pages/user-account/user-account.component';
import { StorePickUpComponent } from './pages/store-pick-up/store-pick-up.component';


@NgModule({
  declarations: [
  
    BannerEcommerceComponent,
    CardCategoryComponent,
    CardProductComponent,
    CategoriesBarComponent,
    FooterComponent,
    HomePageComponent,
    IniciarSesionComponent,
    InternalServerErrorComponent,
    LocalesSenorialComponent,
    NavBarComponent,
    NotFoundPageComponent,
    ShoppingCartComponent,
    StaffPersonalComponent,
    MenuListEcommerceComponent,
    UserAccountComponent,
    StorePickUpComponent,
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
