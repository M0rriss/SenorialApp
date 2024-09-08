import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DetallePedidoResponse } from '@app/core/models/dashboard/pedido/detalle-pedido-response';
import { PedidoLocalResponse } from '@app/core/models/dashboard/pedido/pedido-local-response';
import { PedidoService } from '@app/dashboard/services/pedido/pedido.service';
import {
  ConfirmationService,
  MessageService,
} from "primeng/api";
@Component({
  selector: 'orders-dashboard',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class OrdersComponent implements OnInit {
 pedidos: PedidoLocalResponse[] = [];
 detalle: DetallePedidoResponse[] = [];
  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private pedidoService:PedidoService
) {}
  ngOnInit(): void {
    this.pedidoLocalListado();
  }
confirmPayment(event: Event) {
  this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: '¿Deseas proceder con el Pago?',
      acceptLabel: 'Boleta',
      rejectLabel: 'Factura',
      acceptButtonStyleClass: 'custom-accept-button',
      rejectButtonStyleClass: 'custom-reject-button',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
          this.messageService.add({ severity: 'contrast', summary: 'Boleta Seleccionada', detail: 'Has seleccionado Boleta', life: 3000 });
          this.closeOrderModal();
      },
      reject: () => {
          this.messageService.add({ severity: 'contrast', summary: 'Factura Seleccionada', detail: 'Has seleccionado Factura', life: 3000 });

          this.closeOrderModal();
      }
  });

}
  // Variables para la paginación
  first: number = 0;
  rows: number = 10;
  totalRecords: number = 0;

  isEmployee: boolean = true;

  statusTabs = [
    { label: 'Todos', color: '#abaebc' },
    { label: 'Preparado', color: '#66ffa3' },
    { label: 'Pendiente', color: '#f4c871' },
    { label: 'Facturado', color: '#7798ee' },
    { label: 'Cancelado', color: '#f17474' }
  ];


  selectedOrder: any;
  isCancelModalOpen: boolean = false;
  estado: string = "all";
  selectStatus(status: any) {
    // Logic to filter orders based on status
  }

  getOrderClass(status: number) {
    switch (status) {
      case 1:
        this.estado = "ready-to-serve";
        return 'ready-to-serve';
      case 4:
        this.estado = "cancelled";
        return 'cancelled';
      case 2:
        this.estado = "being-cooked";
        return 'being-cooked';
      case 3:
        this.estado = "invoiced";
        return 'invoiced';
      default:
        return 'all';
    }
  }

  getBadgeClass(status: any) {
    switch (status) {
      case 'Ready to serve':
        return 'ready-badge';
      case 'Cancelled':
        return 'cancelled-badge';
      case 'Being Cooked':
        return 'cooking-badge';
      case 'Invoice':
        return 'invoice-badge';
      default:
        return 'all';
    }
  }
  openOrderModal(order: any) {
    this.selectedOrder = order;
  }

  closeOrderModal() {
    this.selectedOrder = null;
  }

  markAsReady() {
    if (this.selectedOrder) {
      this.pedidoService.pedidoListo(this.selectedOrder.idPedido).subscribe({
        next: (res) => {
          // Mostrar notificación de éxito
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'El pedido ha sido marcado como listo', life: 3000 });

          // Actualizar estado del pedido localmente
          this.selectedOrder!.estado = 1; // Supongamos que 1 es el estado de "listo"
          this.closeOrderModal();
        },
        error: (err) => {
          // Mostrar notificación de error
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un problema al marcar el pedido como listo', life: 3000 });
        }
      });
    }

  }

  openCancelModal() {
    this.isCancelModalOpen = true;
  }

  closeCancelModal() {
    this.isCancelModalOpen = false;
  }

  confirmCancelOrder() {
    if (this.selectedOrder) {
      this.pedidoService.cancelarPedido(this.selectedOrder.idPedido).subscribe({
        next: (res) => {
          // Mostrar notificación de éxito
          this.messageService.add({ severity: 'success', summary: 'Cancelado', detail: 'El pedido ha sido cancelado', life: 3000 });

          // Actualizar estado del pedido localmente (estado 4 es Cancelado)
          this.selectedOrder!.estado = 4;

          // Cerrar el modal
          this.closeCancelModal();
          this.closeOrderModal();
        },
        error: (err) => {
          // Mostrar notificación de error
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un problema al cancelar el pedido', life: 3000 });
        }
      });
    }

  }

  deleteItem(item: any) {
    const index = this.selectedOrder.items.indexOf(item);
    if (index > -1) {
      this.selectedOrder.items.splice(index, 1);

    }
  }

  removeItem(item: any) {
    // Logic to remove item from order
    const index = this.selectedOrder.items.indexOf(item);
    if (index > -1) {
      this.selectedOrder.items.splice(index, 1);
    }
  }


openOrderSummary(order: any) {
  this.selectedOrder = order;
  this.buscarDetallePedido(order.idPedido);
}

onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  //this.listarEmpleados();
}

pedidoLocalListado(){
  this.pedidoService.listarPedidos().subscribe({
    next: (res:PedidoLocalResponse[])=>{
      this.pedidos = res;
    }
  })
}

buscarDetallePedido(idPedido:number){
  this.pedidoService.buscardetallePedido(idPedido).subscribe({
    next: (res:DetallePedidoResponse[])=>{
      this.detalle = res;
    }
  })
}

}
