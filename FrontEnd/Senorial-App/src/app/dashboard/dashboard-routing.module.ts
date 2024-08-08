import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { CashRegisterComponent } from './pages/cash-register/cash-register.component';
import { ClientTableComponent } from './pages/client-table/client-table.component';
import { EmployeeTableComponent } from './pages/employee-table/employee-table.component';
import { InventoryComponent } from './pages/inventory/inventory.component';
import { InvoiceTypeComponent } from './pages/invoice-type/invoice-type.component';
import { LocalComponent } from './pages/local/local.component';
import { CategoryMaintenanceComponent } from './pages/mantenimiento/category-maintenance/category-maintenance.component';
import { PaymentMethodMaintenanceComponent } from './pages/mantenimiento/payment-method-maintenance/payment-method-maintenance.component';
import { ProductMaintenanceComponent } from './pages/mantenimiento/product-maintenance/product-maintenance.component';
import { SuppliesMaintenanceComponent } from './pages/mantenimiento/supplies-maintenance/supplies-maintenance.component';
import { TableMaintenanceComponent } from './pages/mantenimiento/table-maintenance/table-maintenance.component';
import { UserMaintenanceComponent } from './pages/mantenimiento/user-maintenance/user-maintenance.component';
import { MesaDetailComponent } from './pages/mesa-detail/mesa-detail.component';
import { OrdersComponent } from './pages/orders/orders.component';
import { SupplierTableComponent } from './pages/supplier-table/supplier-table.component';

const routes: Routes = [
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
    path      :'mantenimiento-producto',
    component : ProductMaintenanceComponent
  },
  {
    path      :'mantenimiento-insumo',
    component : SuppliesMaintenanceComponent
  },
  {
    path      :'mantenimiento-metodo-pago',
    component : PaymentMethodMaintenanceComponent
  },
  {
    path      :'mantenimiento-categoria',
    component : CategoryMaintenanceComponent
  },
  {
    path      :'mantenimiento-mesa',
    component : TableMaintenanceComponent
  },
  {
    path      :'dash',
    loadChildren: () => import('@app/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes),FormsModule],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
