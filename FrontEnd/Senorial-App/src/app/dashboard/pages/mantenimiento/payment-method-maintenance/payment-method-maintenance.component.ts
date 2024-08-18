import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MetodoPagoRequest } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-request';
import { MetodoPagoResponse } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-response';
import { MetodoPagoService } from '@app/dashboard/services/mantenimineto/metodo-pago/metodo-pago.service';

@Component({
  selector: 'payment-method-maintenance',
  templateUrl: './payment-method-maintenance.component.html',
  styleUrl: './payment-method-maintenance.component.scss'
})
export class PaymentMethodMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Método de Pago';
  modalButtonText: string = 'Agregar';

//
paymentStatus:boolean = true /* para los estados inactivo activo */

 // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;
  //
  formMetodoPago: FormGroup;
  metodoPago: MetodoPagoResponse[] = [];
  idPago:number = 0;

  constructor(private metodoPagoService:MetodoPagoService,
    private fb:FormBuilder,
  ){
    this.formMetodoPago = this.fb.group({
      descripcion : [],
      estado : [],
    })
  }

  ngOnInit(): void {
    this.listarMetodosPago();
  }

  //FUNCIONALIDAD
  listarMetodosPago(){
    this.metodoPagoService.listarMetodoPagos().subscribe({
      next: (res:MetodoPagoResponse[])=>{
        this.metodoPago = res;
      }
    });
  }
  crearMetodoPago(){
    let req = this.formMetodoPago.value as MetodoPagoRequest;
    req.estado = true;
    this.metodoPagoService.crearMetodoPago(req)
      .subscribe({
        next: (res:MetodoPagoResponse)=>{
          alert("mensaje agregado");
        }
      });
  }
  editarMetodoPago(){
    let req = this.formMetodoPago.value as MetodoPagoRequest;
    req.estado = true;
    req.idMetodo = this.idPago;
    this.metodoPagoService.updateMetodoPago(req)
      .subscribe({
        next: (res:MetodoPagoResponse)=>{
          alert("mensaje agregado");
        }
      });
  }
  seveMetodoPago(){
    if(this.modalTitle == 'Agregar Método de Pago'){
      this.crearMetodoPago();
    }
    else{
      this.editarMetodoPago();
    }
  }
  //UI

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

  editMetodoPago(pago:MetodoPagoResponse): void {
    this.formMetodoPago.patchValue({
      descripcion: pago.descripcion
    })
    this.idPago = pago.idMetodo;
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
  // Método para manejar el cambio de página
onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  this.listarMetodosPago();
}
}
