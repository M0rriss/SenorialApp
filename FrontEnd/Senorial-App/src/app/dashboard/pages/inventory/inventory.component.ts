import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

// Interfaz para representar un ítem de inventario
interface InventoryItem {
  name: string;
  unit: string;
  stock: number;
  disponibilidad?: string;
  precioCompra?: string;
  precioVenta?: string;
}

@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss']
})
export class InventoryComponent {
  // Variables para la paginación
  first: number = 0;
  rows: number = 10;
  totalRecords: number = 0;

  // Variables para manejar los diálogos modales
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Editar el Detalle';
  modalButtonText: string = 'Editar';
  selectedItem: InventoryItem | null = null;

  // Variables para manejar los diálogos de entradas y salidas
  isEntryDialogOpen = false;
  isExitDialogOpen = false;

  // Variable para mostrar el detalle del stock
  isStockDetailVisible = false;

  // Formulario reactivo para editar los detalles del inventario
  formDetalle: FormGroup;

  // Datos del inventario
  inventory: InventoryItem[] = [
    { name: 'Papa', unit: 'KG', stock: 50 },
    { name: 'Pollo', unit: 'KG', stock: 20 },
    { name: 'Tomate', unit: 'KG', stock: 5 }
  ];

  // Datos para el detalle de stock
  stocks = [
    { name: 'Papa', unit: 'KG', stock: 50, disponibilidad: 'Suficiente', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' },
    { name: 'Papa', unit: 'KG', stock: 15, disponibilidad: 'En Proceso', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' },
    { name: 'Papa', unit: 'KG', stock: 5, disponibilidad: 'Agotados', precioCompra: 'S/.5.00', precioVenta: 'S/.7.00' }
  ];

  // Constructor para inicializar el formulario
  constructor(private fb: FormBuilder) {
    this.formDetalle = this.fb.group({
      descripcion: [],
      stock: [],
      precioCompra: [],
      precioVenta: [],
    });
  }

  // Método para abrir el diálogo de edición
  openEditDialog(item: InventoryItem) {
    this.selectedItem = item; // Guarda el ítem seleccionado para editar
    this.formDetalle.patchValue({
      descripcion: item.name,
      stock: item.stock,
      // Ajusta aquí los valores para precioCompra y precioVenta si están en tu InventoryItem
    });
    this.modalTitle = 'Editar el Detalle';
    this.modalButtonText = 'Guardar Cambios';
    this.isModalOpen = true;
  }

  // Método para abrir el diálogo de confirmación de eliminación
  openDeleteDialog(item: InventoryItem) {
    this.selectedItem = item; // Guarda el ítem seleccionado para eliminar
    this.isConfirmDialogOpen = true;
  }

  // Método para confirmar la eliminación
  confirmDelete(): void {
    if (this.selectedItem) {
      // Lógica para eliminar el ítem seleccionado
      console.log('Eliminando', this.selectedItem.name);
      // Aquí agregarías la lógica real para eliminar el ítem de la base de datos o el estado
    }
    this.isConfirmDialogOpen = false;
  }

  // Método para cerrar diálogos modales
  closeDialog() {
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = false;
    this.selectedItem = null;
    this.isModalOpen = false;
    this.isConfirmDialogOpen = false;
  }
 // Método para cerrar el diálogo de confirmación
 closeConfirmDialog(): void {
  this.isConfirmDialogOpen = false;
}
  // Método para abrir el diálogo de entrada
  openEntryDialog() {
    this.isEntryDialogOpen = true;
    this.isExitDialogOpen = false;
  }

  // Método para abrir el diálogo de salida
  openExitDialog() {
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = true;
  }

  // Método para realizar una búsqueda en el inventario
  onSearch(event: Event) {
    const query = (event.target as HTMLInputElement).value.toLowerCase();
    this.selectedItem = this.inventory.find(item => item.name.toLowerCase().includes(query)) || null;
  }

  // Método para mostrar el detalle del stock
  showStockDetail() {
    this.isStockDetailVisible = true;
  }

  // Método para ocultar el detalle del stock
  hideStockDetail() {
    this.isStockDetailVisible = false;
  }

  // Método para obtener la disponibilidad del stock
  getDisponibilidad(stock: number): string {
    if (stock > 18) {
      return 'Suficiente';
    } else if (stock > 10) {
      return 'En Proceso';
    } else {
      return 'Agotados';
    }
  }

  // Método para obtener la clase CSS según la cantidad de stock
  getStatusClass(stock: number): string {
    if (stock > 18) {
      return 'status-sufficient';
    } else if (stock > 10) {
      return 'status-processing';
    } else {
      return 'status-out-of-stock';
    }
  }

  // Método para manejar el cambio de página en la paginación
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    // Aquí iría la lógica para manejar el cambio de página
  }

  // Método para manejar las acciones del detalle, como guardar cambios
  detalleAcciones() {
    // Lógica para manejar las acciones del detalle
    console.log('Guardando cambios para:', this.formDetalle.value);
    this.closeDialog(); // Cierra el diálogo después de guardar
  }
}
