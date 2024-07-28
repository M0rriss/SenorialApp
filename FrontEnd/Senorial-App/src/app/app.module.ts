import { AppRoutingModule } from '@app/app-routing.module';
import { BrowserModule }    from '@angular/platform-browser';
import { EcommerceModule }  from '@ecommerce/ecommerce.module';
import { FormsModule }      from '@angular/forms';
import { NgModule }         from '@angular/core';
import { RouterModule }     from '@angular/router';
import { SharedModule }     from '@shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from '@app/app.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    DashboardModule,
    EcommerceModule,
    FormsModule,
    RouterModule,
    SharedModule,
    BrowserAnimationsModule,
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
