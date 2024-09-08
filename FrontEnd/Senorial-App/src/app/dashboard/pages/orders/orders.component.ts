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

  orders = [
    // Pedidos para llevar (PickUp)
    {
      status: 'Ready to serve', table: 1, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' }
      ],
      orderType: 'PickUp'
    },
    {
      status: 'Invoice', table: 4, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/bc656a6c49f29511278ef0db6230e8afb39b1d1cfe88af681bfe8f7344a6547c?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'PickUp'
    },
    // Pedidos para comer aquí (Indoor)
    {
      status: 'Cancelled', table: 2, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/0b170496c4b0a21debaf737164dd77e647143b2fdc9cf06bfbd494626a79de70?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'Indoor'
    },
    {
      status: 'Being Cooked', table: 3, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/bc656a6c49f29511278ef0db6230e8afb39b1d1cfe88af681bfe8f7344a6547c?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'Indoor'
    }
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
    // Logic to mark the order as ready
  }

  openCancelModal() {
    this.isCancelModalOpen = true;
  }

  closeCancelModal() {
    this.isCancelModalOpen = false;
  }

  confirmCancelOrder() {
    // Logic to cancel the order
    this.isCancelModalOpen = false;
    this.closeOrderModal();
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
