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
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;


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
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    //this.listarProveedores(); // Volver a cargar las categorías con la nueva página
  }
}
