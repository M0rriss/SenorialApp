import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from '@dashboard/dashboard-routing.module';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { LocalComponent } from './pages/local/local.component';
import { LogOutComponent } from './components/log-out/log-out.component';
import { MesaDetailComponent } from './pages/mesa-detail/mesa-detail.component';
import { InvoiceTypeComponent } from './pages/invoice-type/invoice-type.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrdersComponent } from './pages/orders/orders.component';
import { CashRegisterComponent } from './pages/cash-register/cash-register.component';
import { InventoryComponent } from './pages/inventory/inventory.component';
import { ClientTableComponent } from './pages/client-table/client-table.component';
import { EmployeeTableComponent } from './pages/employee-table/employee-table.component';
import { SupplierTableComponent } from './pages/supplier-table/supplier-table.component';
import { UserMaintenanceComponent } from './pages/mantenimiento/user-maintenance/user-maintenance.component';
import { ProductMaintenanceComponent } from './pages/mantenimiento/product-maintenance/product-maintenance.component';
import { SuppliesMaintenanceComponent } from './pages/mantenimiento/supplies-maintenance/supplies-maintenance.component';
import { PaymentMethodMaintenanceComponent } from './pages/mantenimiento/payment-method-maintenance/payment-method-maintenance.component';
import { CategoryMaintenanceComponent } from './pages/mantenimiento/category-maintenance/category-maintenance.component';
import { TableMaintenanceComponent } from './pages/mantenimiento/table-maintenance/table-maintenance.component';


@NgModule({
  declarations: [

    SideBarComponent,
       LocalComponent,
       LogOutComponent,
       MesaDetailComponent,
       InvoiceTypeComponent,
       OrdersComponent,
       CashRegisterComponent,
       InventoryComponent,
       ClientTableComponent,
       EmployeeTableComponent,
       SupplierTableComponent,
       UserMaintenanceComponent,
       ProductMaintenanceComponent,
       SuppliesMaintenanceComponent,
       PaymentMethodMaintenanceComponent,
       CategoryMaintenanceComponent,
       TableMaintenanceComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DashboardModule { }
