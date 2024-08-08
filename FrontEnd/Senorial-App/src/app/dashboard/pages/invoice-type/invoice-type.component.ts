import { Component } from '@angular/core';

@Component({
  selector: 'invoice-type',
  templateUrl: './invoice-type.component.html',
  styleUrl: './invoice-type.component.scss'
})
export class InvoiceTypeComponent {
  selectedOption: string = 'boleta';
  selectedPaymentOption: string = '';
  dniValue: string = ''; // Example DNI value
  rucValue: string = ''; // Example RUC value
  documentValue: string = '';
  isModalOpen = false;
  amount: number = 0.00;

  selectOption(option: string) {
    this.selectedOption = option;
  }

  selectPaymentOption(option: string) {
    this.selectedPaymentOption = option;
  }

  openModal() {
    this.isModalOpen = true;
  }

  closeModal(event: MouseEvent) {
    this.isModalOpen = false;
  }

  submitPayment() {
    // Logic to handle the payment submission
  }

  buscarDatosReniec() {
    // Logic to search for data in Reniec
  }
}
