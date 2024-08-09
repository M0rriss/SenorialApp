import { Component, OnInit } from '@angular/core';
import { MesaResponse } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-response';
import { MesaService } from '@app/dashboard/services/mantenimineto/mesa/mesa.service';

@Component({
  selector: 'table-maintenance',
  templateUrl: './table-maintenance.component.html',
  styleUrl: './table-maintenance.component.scss'
})
export class TableMaintenanceComponent implements OnInit {
  mesas = [
    { name: 'Mesa 1', active: true },
    { name: 'Mesa 2', active: false },
    { name: 'Mesa 3', active: true },
    { name: 'Mesa 4', active: true }
  ];

  isAddEditDialogOpen = false;
  isConfirmDialogOpen = false;
  dialogTitle = 'Add Mesas';
  dialogActionButton = 'Add Mesas';

  mesaName = '';
  mesaStatus = '';
  selectedMesa: any = null;

  //MESAS
  mesasList:MesaResponse[] = [];
  constructor(private mesaService:MesaService){}
  ngOnInit(): void {
    this.listarMesas();
  }

  //FUNCIONAMINETO
  listarMesas(){
    this.mesaService.getAll()
      .subscribe({
        next: (data: MesaResponse[])=>{
          this.mesasList = data;
        }
      });
  }

  // Abrir diálogo de agregar mesa
  openAddDialog() {
    this.dialogTitle = 'Add Mesas';
    this.dialogActionButton = 'Add Mesas';
    this.mesaName = '';
    this.mesaStatus = '';
    this.selectedMesa = null;
    this.isAddEditDialogOpen = true;
  }

  // Abrir diálogo de editar mesa
  openEditDialog(mesa: any) {
    this.dialogTitle = 'Edit Mesas';
    this.dialogActionButton = 'Save Changes';
    this.mesaName = mesa.name;
    this.mesaStatus = mesa.active ? 'Active' : 'Inactive';
    this.selectedMesa = mesa;
    this.isAddEditDialogOpen = true;
  }

  // Guardar mesa (agregar o editar)
  saveMesa() {
    if (this.selectedMesa) {
      // Editar mesa existente
      this.selectedMesa.name = this.mesaName;
      this.selectedMesa.active = this.mesaStatus === 'Active';
    } else {
      // Agregar nueva mesa
      this.mesas.push({
        name: this.mesaName,
        active: this.mesaStatus === 'Active'
      });
    }
    this.isAddEditDialogOpen = false;
  }

  // Cerrar diálogo de agregar/editar
  closeAddEditDialog() {
    this.isAddEditDialogOpen = false;
  }

  // Abrir diálogo de confirmación de eliminación
  openConfirmDialog(mesa: any) {
    this.selectedMesa = mesa;
    this.isConfirmDialogOpen = true;
  }

  // Confirmar eliminación de mesa
  confirmDelete() {
    this.mesas = this.mesas.filter(m => m !== this.selectedMesa);
    this.isConfirmDialogOpen = false;
    this.selectedMesa = null;
  }

  // Cerrar diálogo de confirmación
  closeConfirmDialog() {
    this.isConfirmDialogOpen = false;
    this.selectedMesa = null;
  }
}
