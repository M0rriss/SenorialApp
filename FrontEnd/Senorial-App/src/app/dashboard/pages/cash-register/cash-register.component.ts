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
  isDetailCountOpen: boolean = false;

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
  }
}
