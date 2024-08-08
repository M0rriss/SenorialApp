import { Component } from '@angular/core';

@Component({
  selector: 'supplies-maintenance',
  templateUrl: './supplies-maintenance.component.html',
  styleUrl: './supplies-maintenance.component.scss'
})
export class SuppliesMaintenanceComponent {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Insumo';
  modalButtonText: string = 'Agregar';

  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Insumo';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Insumo';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.isModalOpen = false;
  }

  addInsumo(): void {
    this.openDialog('add');
  }

  editInsumo(): void {
    this.openDialog('edit');
  }

  deleteInsumo(): void {
    // Lógica para eliminar insumo
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de insumo
    this.deleteInsumo();
  }
}
