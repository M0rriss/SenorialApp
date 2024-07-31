import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from '@pages-ecommerce/home-page/home-page.component';
import { LocalComponent } from './dashboard/pages/local/local.component';
import { MesaDetailComponent } from './dashboard/pages/mesa-detail/mesa-detail.component';
import { InvoiceTypeComponent } from './dashboard/pages/invoice-type/invoice-type.component';
import { OrdersComponent } from './dashboard/pages/orders/orders.component';
import { CashRegisterComponent } from './dashboard/pages/cash-register/cash-register.component';
import { InventoryComponent } from './dashboard/pages/inventory/inventory.component';
import { ClientTableComponent } from './dashboard/pages/client-table/client-table.component';
import { EmployeeTableComponent } from './dashboard/pages/employee-table/employee-table.component';
import { SupplierTableComponent } from './dashboard/pages/supplier-table/supplier-table.component';
import { UserMaintenanceComponent } from './dashboard/pages/mantenimiento/user-maintenance/user-maintenance.component';

const routes: Routes = [
  {
    path      :'home',
    component : HomePageComponent
  },
  {
    path      :'dashboard',
    component : LocalComponent
  },
  {
    path      :'mesadetail',
    component : MesaDetailComponent
  },
  {
    path      :'invoice',
    component : InvoiceTypeComponent
  },
  {
    path      :'pedidos',
    component : OrdersComponent
  },
  {
    path      :'caja',
    component : CashRegisterComponent
  },
  {
    path      :'inventario',
    component : InventoryComponent
  },
  {
    path      :'cliente',
    component : ClientTableComponent
  },
  {
    path      :'proveedor',
    component : SupplierTableComponent
  },
  {
    path      :'empleado',
    component : EmployeeTableComponent
  },
  {
    path      :'mantenimiento-usuario',
    component : UserMaintenanceComponent
  },
  {
    path      :'empleado',
    component : EmployeeTableComponent
  },
  {
    path      :'empleado',
    component : EmployeeTableComponent
  },
  {
    path      :'empleado',
    component : EmployeeTableComponent
  },

  // {
  //   path      :'**',
  //   redirectTo:'home'
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
