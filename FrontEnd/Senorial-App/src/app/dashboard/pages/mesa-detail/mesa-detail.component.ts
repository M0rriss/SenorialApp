import { Component } from '@angular/core';

@Component({
  selector: 'mesa-detail',
  templateUrl: './mesa-detail.component.html',
  styleUrl: './mesa-detail.component.scss'
})
export class MesaDetailComponent {
  selectedReceiptOption: string = 'Boleta';

  selectOption(option: string): void {
    this.selectedReceiptOption = option;
  }
}
