import { Component } from '@angular/core';

@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.scss'
})
export class EmployeeTableComponent {
  isModalOpen: boolean = false;
  modalTitle: string = '';
  modalButtonText: string = '';

  openDialog(action: string): void {
    if (action === 'add') {
      this.modalTitle = 'Agregar Empleado';
      this.modalButtonText = 'Agregar Empleado';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Empleado';
      this.modalButtonText = 'Editar Empleado';
    }
    this.isModalOpen = true;
  }

  closeDialog(): void {
    this.isModalOpen = false;
  }
}
