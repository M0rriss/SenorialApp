import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'invoice-type',
  templateUrl: './invoice-type.component.html',
  styleUrl: './invoice-type.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class InvoiceTypeComponent {
  selectedOption: string = 'factura';
  selectedPaymentOption: string = '';
  dniValue: string = ''; // Example DNI value
  rucValue: string = ''; // Example RUC value
  documentValue: string = '';
  isModalOpen = false;
  amount: number = 0.00;

  visible: boolean = false;


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
  showDialog() {
    this.visible = true;
  }
}
