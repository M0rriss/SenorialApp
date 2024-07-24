import { AppRoutingModule } from '@app/app-routing.module';
import { BrowserModule }    from '@angular/platform-browser';
import { EcommerceModule }  from '@ecommerce/ecommerce.module';
import { NgModule }         from '@angular/core';
import { RouterModule }     from '@angular/router';
import { SharedModule }     from '@shared/shared.module';


import { AppComponent } from '@app/app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    EcommerceModule,
    RouterModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
