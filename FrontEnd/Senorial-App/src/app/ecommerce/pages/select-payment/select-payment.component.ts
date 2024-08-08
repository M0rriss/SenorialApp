import { Component } from '@angular/core';


@Component({
  selector: 'select-payment',
  templateUrl: './select-payment.component.html',
  styleUrl: './select-payment.component.scss'
})
export class SelectPaymentComponent {

  showForm = false;
  selectedPaymentMethod: string | null = null;
}
