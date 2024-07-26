import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from '@dashboard/dashboard-routing.module';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { LocalComponent } from './pages/local/local.component';
import { LogOutComponent } from './components/log-out/log-out.component';
import { MesaDetailComponent } from './pages/mesa-detail/mesa-detail.component';


@NgModule({
  declarations: [
  
    SideBarComponent,
       LocalComponent,
       LogOutComponent,
       MesaDetailComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
