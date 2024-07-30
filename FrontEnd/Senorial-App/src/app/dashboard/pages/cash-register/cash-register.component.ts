import { Component } from '@angular/core';

@Component({
  selector: 'cash-register',
  templateUrl: './cash-register.component.html',
  styleUrl: './cash-register.component.scss'
})
export class CashRegisterComponent {
  activeTab: string = 'abrir';
  isModalOpen: boolean = false;
  showDetails: boolean = false;
  selectedCashRegister: any = null;

  isDetailCountOpen = false;
  coinQuantities: { [key: number]: number } = { 0.10: 0, 0.20: 0, 0.50: 0, 1.00: 0, 2.00: 0, 5.00: 0 };
  billQuantities: { [key: number]: number } = { 10.00: 0, 20.00: 0, 50.00: 0, 100.00: 0, 200.00: 0 };
  totalAmount = 0;

  increaseQty(type: string, value: number) {
    if (type === 'coin') {
      this.coinQuantities[value]++;
    } else if (type === 'bill') {
      this.billQuantities[value]++;
    }
    this.calculateTotal();
  }

  calculateTotal() {
    this.totalAmount = 0;
    for (const [coin, qty] of Object.entries(this.coinQuantities)) {
      this.totalAmount += parseFloat(coin) * qty;
    }
    for (const [bill, qty] of Object.entries(this.billQuantities)) {
      this.totalAmount += parseFloat(bill) * qty;
    }
  }

  openRegister(): void {
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
  }

  selectTab(tab: string): void {
    this.activeTab = tab;
    this.showDetails = false; // Reset to hide details view when changing tabs
  }

  viewDetails(cashRegister: any): void {
    this.selectedCashRegister = cashRegister;
    this.showDetails = true;
  }

  backToHistory(): void {
    this.showDetails = false;
    this.selectedCashRegister = null;
  }

  openDetailCount() {
    this.isDetailCountOpen = true;
  }

  closeDetailCount() {
    this.isDetailCountOpen = false;
    this.totalAmount = 0;
  }
}
