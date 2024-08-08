import { Component } from '@angular/core';

@Component({
  selector: 'payment-method-maintenance',
  templateUrl: './payment-method-maintenance.component.html',
  styleUrl: './payment-method-maintenance.component.scss'
})
export class PaymentMethodMaintenanceComponent {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Método de Pago';
  modalButtonText: string = 'Agregar';

  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Método de Pago';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Método de Pago';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.isModalOpen = false;
  }

  addMetodoPago(): void {
    this.openDialog('add');
  }

  editMetodoPago(): void {
    this.openDialog('edit');
  }

  deleteMetodoPago(): void {
    // Lógica para eliminar método de pago
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de método de pago
    this.deleteMetodoPago();
  }
}
