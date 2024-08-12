import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { InsumoRequest } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-request';
import { InsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-response';
import { InsumoService } from '@app/dashboard/services/mantenimineto/insumos/insumo.service';

@Component({
  selector: 'supplies-maintenance',
  templateUrl: './supplies-maintenance.component.html',
  styleUrl: './supplies-maintenance.component.scss'
})
export class SuppliesMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Insumo';
  modalButtonText: string = 'Agregar';
 // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;
  //SUMINISTRO
  formInsumo:FormGroup;
  suministro: InsumoResponse[] = [];

  constructor(private insumoService:InsumoService,
    private fb:FormBuilder
  ){
    this.formInsumo = this.fb.group({
      insumoNombre : [],
      unidadMedida : [],
    });
  }
  ngOnInit(): void {
    this.listarSuministro();
  }

  //FUNCIONAMIENTO
  listarSuministro(){
    this.insumoService.listarInsumo()
      .subscribe({
        next: (res:InsumoResponse[])=>{
          this.suministro = res;
        }
      });
  }
  agregarInsumo(){
    let req = this.formInsumo.value as InsumoRequest;
    this.insumoService.crearInsumo(req)
    .subscribe({
      next: (res: InsumoResponse) => {
        alert("se registro correctamente")
      }
    });
  }
  eliminarInsumo(idInsumo:number){
    this.insumoService.eliminarInsumo(idInsumo)
      .subscribe({
        next: (res: boolean)=>{
          console.log(res);
        }
      });
  }

  //UI
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
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    this.listarSuministro();
  }
}
