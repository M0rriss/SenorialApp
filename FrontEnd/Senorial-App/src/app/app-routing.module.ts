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
import { ProductMaintenanceComponent } from './dashboard/pages/mantenimiento/product-maintenance/product-maintenance.component';
import { SuppliesMaintenanceComponent } from './dashboard/pages/mantenimiento/supplies-maintenance/supplies-maintenance.component';
import { PaymentMethodMaintenanceComponent } from './dashboard/pages/mantenimiento/payment-method-maintenance/payment-method-maintenance.component';
import { CategoryMaintenanceComponent } from './dashboard/pages/mantenimiento/category-maintenance/category-maintenance.component';
import { TableMaintenanceComponent } from './dashboard/pages/mantenimiento/table-maintenance/table-maintenance.component';

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
    path      :'manteniminento-usuario',
    component : UserMaintenanceComponent
  },
  {
    path      :'manteniminento-producto',
    component : ProductMaintenanceComponent
  },
  {
    path      :'manteniminento-insumo',
    component : SuppliesMaintenanceComponent
  },
  {
    path      :'manteniminento-metodo-pago',
    component : PaymentMethodMaintenanceComponent
  },
  {
    path      :'manteniminento-categoria',
    component : CategoryMaintenanceComponent
  },
  {
    path      :'manteniminento-mesa',
    component : TableMaintenanceComponent
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
