import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MetodoPagoRequest } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-request';
import { MetodoPagoResponse } from '@app/core/models/dashboard/mantenimiento/metodo-pago/metodo-pago-response';
import { MetodoPagoService } from '@app/dashboard/services/mantenimineto/metodo-pago/metodo-pago.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'payment-method-maintenance',
  templateUrl: './payment-method-maintenance.component.html',
  styleUrl: './payment-method-maintenance.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class PaymentMethodMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Método de Pago';
  modalButtonText: string = 'Agregar';

  //Estado del método de pago
paymentStatus:boolean = true /* para los estados inactivo activo */

 // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;
  //Formulario
  formMetodoPago: FormGroup;
  metodoPago: MetodoPagoResponse[] = [];
  idPago:number = 0;
// Variables para el diálogo de confirmación
confirmDialogTitle: string = '';
confirmDialogDescription: string = '';
currentMetodoPago: MetodoPagoResponse | null = null;

  constructor(private metodoPagoService:MetodoPagoService,
    private fb:FormBuilder,
    private notificationService: NotificationService,

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
          this.notificationService.showSuccess('Creado exitosamente', 'Éxito');
        this.closeDialog();
      },
      error: () => {
        this.notificationService.showError('Error al crear', 'Error');
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
          this.notificationService.showSuccess('Actualizado exitosamente', 'Éxito');
        this.closeDialog();
      },
      error: () => {
        this.notificationService.showError('Error al actualizar', 'Error');
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
      this.formMetodoPago.reset();
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Método de Pago';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.listarMetodosPago  ();
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

  openConfirmDialog(pago: MetodoPagoResponse, isEnabled: boolean): void {
    this.currentMetodoPago = pago;
    this.isConfirmDialogOpen = true;

    if (isEnabled) {
      this.confirmDialogTitle = '¿Quieres inhabilitar el método de pago?';
      this.confirmDialogDescription = '¿Estás seguro que quieres inhabilitar este método de pago?';
    } else {
      this.confirmDialogTitle = '¿Quieres habilitar el método de pago?';
      this.confirmDialogDescription = '¿Estás seguro que quieres habilitar este método de pago?';
    }
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
    this.currentMetodoPago = null;
  }

  confirmDelete(): void {
    if (this.currentMetodoPago) {
      this.deleteMetodoPago();
    }
    this.closeConfirmDialog();
  }
  // Método para manejar el cambio de página
onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  this.listarMetodosPago();
}
}
