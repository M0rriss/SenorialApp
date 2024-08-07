import { Component, ElementRef, OnInit, ViewChild, Renderer2 } from '@angular/core';
import { StepsModule } from 'primeng/steps';
import { MenuItem } from 'primeng/api';
import { ButtonModule } from 'primeng/button';

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
export class StorePickUpComponent implements OnInit {
  @ViewChild('stepOne', { static: true }) stepOne: ElementRef | undefined;
  @ViewChild('stepTwo', { static: true }) stepTwo: ElementRef | undefined;

  stores: Store[] = [
    { name: 'Local Pio Pata', address: 'Av. Circuito los heroes 343', isSelected: true },
    { name: 'Local de Chilca', address: 'Circuito Los Heroes', isSelected: false }
  ];
  renderer: any;

  selectStore(selectedStore: Store): void {
    this.stores.forEach(store => store.isSelected = false);
    selectedStore.isSelected = true;
  }
  items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      { label: 'Despacho' },
      { label: 'Pago' }
    ];

    // Aplica estilos dinámicos
    this.applyStyles();
  }
  applyStyles() {
    if (this.stepOne && this.stepTwo) {
      this.renderer.setStyle(this.stepOne.nativeElement, 'background-color', '#ff910f');
      this.renderer.setStyle(this.stepOne.nativeElement, 'color', '#fff');

      this.renderer.setStyle(this.stepTwo.nativeElement, 'background-color', '#79797c');
      this.renderer.setStyle(this.stepTwo.nativeElement, 'color', '#fff');
    }
  }
}
