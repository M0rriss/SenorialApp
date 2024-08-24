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
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { MessagesModule } from 'primeng/messages';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { AuthInterceptor } from '@app/service/auth.interceptor';
import { PaginatorModule } from 'primeng/paginator';
import { PrimeIcons } from 'primeng/api';
import { PusherService } from '@app/ecommerce/services/pusher/pusher.service';
import { SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider } from '@abacritt/angularx-social-login';
import "angular2-navigate-with-data"
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
    HttpClientModule,
    MessagesModule,
    ToastModule,
    PaginatorModule,


  ],
  providers: [
    PusherService,
    MessageService,
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '468788154430-n20dduv7dr1l9rli5skivolpd9ist4lq.apps.googleusercontent.com'  // Reemplaza con tu Client ID
            )
          }
        ]
      } as SocialAuthServiceConfig,
    },


    provideHttpClient(withInterceptors([AuthInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
