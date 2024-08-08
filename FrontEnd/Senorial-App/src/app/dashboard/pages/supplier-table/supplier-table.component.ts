import { Component } from '@angular/core';

@Component({
  selector: 'app-supplier-table',
  templateUrl: './supplier-table.component.html',
  styleUrl: './supplier-table.component.scss'
})
export class SupplierTableComponent {
  isModalOpen = false;
  modalTitle = 'Agregar Proveedor';
  modalButtonText = 'Agregar Proveedor';

  openDialog(action: string) {
    if (action === 'add') {
      this.modalTitle = 'Agregar Proveedor';
      this.modalButtonText = 'Agregar Proveedor';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Proveedor';
      this.modalButtonText = 'Guardar Cambios';
    }
    this.isModalOpen = true;
  }

  closeDialog() {
    this.isModalOpen = false;
  }
}
