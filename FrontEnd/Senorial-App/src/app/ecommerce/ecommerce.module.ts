import { NgModule }     from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { EcommerceRoutingModule } from '@ecommerce/ecommerce-routing.module';

import { AddItemToCheckoutComponent }   from '@pages-ecommerce/add-item-to-checkout/add-item-to-checkout.component';
import { BannerEcommerceComponent }     from '@components-ecommerce/banner-ecommerce/banner-ecommerce.component';
import { CardCategoryComponent }        from '@components-ecommerce/card-category/card-category.component';
import { CardProductComponent }         from '@components-ecommerce/card-product/card-product.component';
import { CategoriesBarComponent }       from '@components-ecommerce/categories-bar/categories-bar.component';
import { CheckOutComponent }            from '@pages-ecommerce/check-out/check-out.component';
import { FooterComponent }              from '@components-ecommerce/footer/footer.component';
import { HomePageComponent }            from '@pages-ecommerce/home-page/home-page.component';
import { IniciarSesionComponent }       from '@components-ecommerce/iniciar-sesion/iniciar-sesion.component';
import { InternalServerErrorComponent } from '@pages-ecommerce/internal-server-error/internal-server-error.component';
import { LocalesSenorialComponent }     from '@pages-ecommerce/locales-senorial/locales-senorial.component';
import { MenuListEcommerceComponent }   from '@components-ecommerce/menu-list-ecommerce/menu-list-ecommerce.component';
import { NavBarComponent }              from '@components-ecommerce/nav-bar/nav-bar.component';
import { NotFoundPageComponent }        from '@pages-ecommerce/not-found-page/not-found-page.component';
import { SelectPaymentComponent }       from '@pages-ecommerce/select-payment/select-payment.component';
import { ShoppingCartComponent }        from '@components-ecommerce/shopping-cart/shopping-cart.component';
import { StaffPersonalComponent }       from '@components-ecommerce/staff-personal/staff-personal.component';
import { StorePickUpComponent }         from '@pages-ecommerce/store-pick-up/store-pick-up.component';
import { UserAccountComponent }         from '@pages-ecommerce/user-account/user-account.component';
import { SharedModule } from '@app/shared/shared.module';


@NgModule({
  declarations: [

    AddItemToCheckoutComponent,
    BannerEcommerceComponent,
    CardCategoryComponent,
    CardProductComponent,
    CategoriesBarComponent,
    CheckOutComponent,
    FooterComponent,
    HomePageComponent,
    IniciarSesionComponent,
    InternalServerErrorComponent,
    LocalesSenorialComponent,
    MenuListEcommerceComponent,
    NavBarComponent,
    NotFoundPageComponent,
    SelectPaymentComponent,
    ShoppingCartComponent,
    StaffPersonalComponent,
    StorePickUpComponent,
    UserAccountComponent,
  ],
  imports: [
    CommonModule,
    EcommerceRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule
  ],
  exports: [
    NavBarComponent,
    BannerEcommerceComponent,
    CategoriesBarComponent
  ]
})
export class EcommerceModule { }
