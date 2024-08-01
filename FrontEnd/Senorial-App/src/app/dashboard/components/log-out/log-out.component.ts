import { Component } from '@angular/core';

@Component({
  selector: 'log-out',
  templateUrl: './log-out.component.html',
  styleUrl: './log-out.component.scss'
})
export class LogOutComponent {

  email:string = 'admin@admin.com'
  isConfirmDialogOpen: boolean = false;
  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }
  deleteProduct(): void {
    // Lógica para eliminar producto
    this.isConfirmDialogOpen = false;
  }
  confirmDelete(): void {
    // Lógica para confirmar eliminación de producto
    this.deleteProduct();
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }
}
