import { Component } from '@angular/core';

@Component({
  selector: 'orders-dashboard',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent {
  statusTabs = [
    { label: 'Todos', color: '#abaebc' },
    { label: 'Preparado', color: '#66ffa3' },
    { label: 'Pendiente', color: '#f4c871' },
    { label: 'Facturado', color: '#7798ee' },
    { label: 'Cancelado', color: '#f17474' }
  ];

  orders = [
    {
      status: 'Ready to serve', table: 1, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://www.foodandwine.com/thmb/XE8ubzwObCIgMw7qJ9CsqUZocNM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/MSG-Smash-Burger-FT-RECIPE0124-d9682401f3554ef683e24311abdf342b.jpg' },
      ],
      orderType: 'PickUp'
    },
    {
      status: 'Cancelled', table: 2, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/0b170496c4b0a21debaf737164dd77e647143b2fdc9cf06bfbd494626a79de70?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'PickUp'
    },
    {
      status: 'Being Cooked', table: 3, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/bc656a6c49f29511278ef0db6230e8afb39b1d1cfe88af681bfe8f7344a6547c?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'Indoor'
    },
    {
      status: 'Invoice', table: 4, customerName: 'Mauricio', items: [
        { title: 'The classics for 3', description: '1 McChicken, 1 Big Mac, 1 Royal Cheeseburger', price: 'PEN 23.10', image: 'https://cdn.builder.io/api/v1/image/assets/TEMP/bc656a6c49f29511278ef0db6230e8afb39b1d1cfe88af681bfe8f7344a6547c?apiKey=217b68ba2ab24926b015d8eb14374581&&apiKey=217b68ba2ab24926b015d8eb14374581' }
      ],
      orderType: 'Indoor'
    }
  ];

  selectedOrder: any;
  isCancelModalOpen: boolean = false;
  selectStatus(status: any) {
    // Logic to filter orders based on status
  }

  getOrderClass(status: any) {
    switch (status) {
      case 'Ready to serve':
        return 'ready-to-serve';
      case 'Cancelled':
        return 'cancelled';
      case 'Being Cooked':
        return 'being-cooked';
      case 'Invoice':
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
}



}
