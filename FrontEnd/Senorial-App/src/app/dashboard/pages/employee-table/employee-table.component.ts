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
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;


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
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    //this.listarEmpleados();
  }
}
