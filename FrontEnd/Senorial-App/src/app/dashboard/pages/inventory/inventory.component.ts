import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
interface InventoryItem {
  name: string;
  unit: string;
  stock: number;
}
@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.scss'
})

export class InventoryComponent {
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;
//modal
isModalOpen: boolean = false;
isConfirmDialogOpen: boolean = false;
modalTitle: string = 'Editar el Detalle';
modalButtonText: string = 'Editar';
idProducto:number = 0;
formDetalle:FormGroup;

constructor(private fb:FormBuilder){
this.formDetalle = this.fb.group({
  descripcion:[],
  stock:[],
  precioCompra:[],
  precioVenta:[],
})
}
 isEntryDialogOpen = false;
  isExitDialogOpen = false;
  isStockDetailVisible = false;
  selectedItem: InventoryItem | null = null;
  inventory: InventoryItem[] = [
    { name: 'Papa', unit: 'KG', stock: 50 },
    { name: 'Pollo', unit: 'KG', stock: 20 },
    { name: 'Tomate', unit: 'KG', stock: 5 }
  ];
  detalleAcciones(){

  }
  triggerFileInput(): void {
    const fileInput = document.getElementById('fileInput') as HTMLInputElement;
    fileInput.click();
  }
  openEntryDialog() {
    this.isEntryDialogOpen = true;
    this.isExitDialogOpen = false;
  }

  openExitDialog() {
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = true;
  }

  closeDialog() {
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = false;
    this.selectedItem = null;
  }

  onSearch(event: Event) {
    const query = (event.target as HTMLInputElement).value.toLowerCase();
    this.selectedItem = this.inventory.find(item => item.name.toLowerCase().includes(query)) || null;
  }
  getInventoryItem(query: string) {
    const inventory = [
      { name: 'Papa', stock: 50 },
      { name: 'Pollo', stock: 20 },
      { name: 'Tomate', stock: 5 }
    ];
    return inventory.find(item => item.name.toLowerCase().includes(query));
  }
  showStockDetail() {
    this.isStockDetailVisible = true;
  }

  hideStockDetail() {
    this.isStockDetailVisible = false;
  }
  stocks = [
    { descripcion: 'Papa', stock: 50, disponibilidad: 'Suficiente', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' },
    { descripcion: 'Papa', stock: 15, disponibilidad: 'En Proceso', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' },
    { descripcion: 'Papa', stock: 5, disponibilidad: 'Agotados', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' }
  ];

  getDisponibilidad(stock: number): string {
    if (stock > 18) {
      return 'Suficiente';
    } else if (stock > 10) {
      return 'En Proceso';
    } else {
      return 'Agotados';
    }
  }

  getStatusClass(stock: number): string {
    if (stock > 18) {
      return 'status-sufficient';
    } else if (stock > 10) {
      return 'status-processing';
    } else {
      return 'status-out-of-stock';
    }
  }
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    //this.listarInventario();
  }
  deleteDetail(): void {
    // Lógica para eliminar usuario
    this.isConfirmDialogOpen = false;
  }
  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de usuario
    this.deleteDetail();
  }
}
