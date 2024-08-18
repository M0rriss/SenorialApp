import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MesaRequest } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-request';
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
  formMesa:FormGroup;
  idMesa: number = 0;
  constructor(private mesaService:MesaService,
    private fb:FormBuilder
  ){
    this.formMesa = this.fb.group({
      nombre:[],
      estado:[]
    })
  }
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
  crearMesa(){
    let req = this.formMesa.value as MesaRequest;
    req.idMesa=0;
    this.mesaService.crearRegistro(req).subscribe({
      next: (res: MesaResponse)=>{
        alert("registro Correcto")
      }
    })
  }
  editarMesa(){
    let req = this.formMesa.value as MesaRequest;
    req.idMesa = this.idMesa;
    this.mesaService.actulizarRegistro(req).subscribe({
      next: (res: MesaResponse)=>{
        alert("registro Correcto")
      }
    })
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
    this.formMesa.patchValue({
      nombre: mesa.nombre,
      estado: mesa.estado
    });
    this.idMesa = mesa.idMesa;
    this.dialogTitle = 'Edit Mesas';
    this.dialogActionButton = 'Save Changes';
    this.mesaName = mesa.name;
    this.mesaStatus = mesa.active ? 'Active' : 'Inactive';
    this.selectedMesa = mesa;
    this.isAddEditDialogOpen = true;
  }

  // Guardar mesa (agregar o editar)
  saveMesa() {
    if (this.selectedMesa == null) {
      this.crearMesa()
      // Editar mesa existente
      this.selectedMesa.name = this.mesaName;
      this.selectedMesa.active = this.mesaStatus === 'Active';
    } else {
      this.editarMesa();
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
