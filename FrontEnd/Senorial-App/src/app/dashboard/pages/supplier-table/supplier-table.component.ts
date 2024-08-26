import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProveedorResponse } from '@app/core/models/dashboard/proveedores/proveedor.response';
import { ProveedorService } from '@app/dashboard/services/clientes/proveedor/proveedor.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'app-supplier-table',
  templateUrl: './supplier-table.component.html',
  styleUrl: './supplier-table.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class SupplierTableComponent implements OnInit {
  isModalOpen = false;
  modalTitle = 'Agregar Proveedor';
  modalButtonText = 'Agregar Proveedor';
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;

suppliers:ProveedorResponse[] = [];
formSupplier:FormGroup;
idProveedor: number = 0;
constructor(
private proveedorService: ProveedorService,
private fb:FormBuilder ,
  private notificationService:NotificationService ,
){
this.formSupplier = this.fb.group({
  idProveedor:             [],
  proveedorNombreCompleto: [],
  correo:                  [],
  telefono:                [],
  dni:                     [],
  distribuye:              [],
})
}
  ngOnInit(): void {
    this.listarProveedores()
  }

listarProveedores(){
  this.proveedorService.getAll().subscribe({
    next: (res:ProveedorResponse[]) =>{
      this.suppliers = res;
    }
  })
}
crearProveedor() {
  const req = this.formSupplier.value;
  this.proveedorService.crearRegistro(req).subscribe({
    next: (res: ProveedorResponse) => {
      this.notificationService.showSuccess('Proveedor creado exitosamente', 'Éxito');
      this.closeDialog();
      this.listarProveedores(); // Recargar la lista de proveedores
    },
    error: () => {
      this.notificationService.showError('Error al crear el proveedor', 'Error');
    }
  });
}

editarProveedor() {
  const req = this.formSupplier.value;
  req.idProveedor = this.idProveedor; // Asegurarse de que el ID del proveedor se mantenga
  this.proveedorService.actulizarRegistro(req).subscribe({
    next: (res: ProveedorResponse) => {
      this.notificationService.showSuccess('Proveedor actualizado exitosamente', 'Éxito');
      this.closeDialog();
      this.listarProveedores(); // Recargar la lista de proveedores
    },
    error: () => {
      this.notificationService.showError('Error al actualizar el proveedor', 'Error');
    }
  });
}






openDialog(action: string, proveedor?: ProveedorResponse) {
  this.isModalOpen = true;
  if (action === 'add') {
    this.modalTitle = 'Agregar Proveedor';
    this.modalButtonText = 'Agregar Proveedor';
    this.formSupplier.reset(); // Limpiar el formulario al agregar un nuevo proveedor
  } else if (action === 'edit' && proveedor) {
    this.modalTitle = 'Editar Proveedor';
    this.modalButtonText = 'Guardar Cambios';
    this.formSupplier.patchValue({
      proveedorNombreCompleto: proveedor.proveedorNombreCompleto,
      correo: proveedor.correo,
      telefono: proveedor.telefono,
      dni: proveedor.dni,
      distribuye: proveedor.distribuye,
    });
    this.idProveedor = proveedor.idProveedor; // Guardar el ID del proveedor que se está editando
  }
} submitForm() {
  if (this.modalButtonText === 'Agregar Proveedor') {
    this.crearProveedor();
  } else {
    this.editarProveedor();
  }
}
  closeDialog() {
    this.isModalOpen = false;
  }
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    //this.listarProveedores(); // Volver a cargar las categorías con la nueva página
  }
}
