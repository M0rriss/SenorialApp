import { Component } from '@angular/core';

interface Store {
  name: string;
  address: string;
  isSelected: boolean;
}
@Component({
  selector: 'store-pick-up',
  templateUrl: './store-pick-up.component.html',
  styleUrl: './store-pick-up.component.scss'
})
export class StorePickUpComponent {
  stores: Store[] = [
    { name: 'Local Pio Pata', address: 'Av. Circuito los heroes 343', isSelected: true },
    { name: 'Local de Chilca', address: 'Circuito Los Heroes', isSelected: false }
  ];

  selectStore(selectedStore: Store): void {
    this.stores.forEach(store => store.isSelected = false);
    selectedStore.isSelected = true;
  }
}
