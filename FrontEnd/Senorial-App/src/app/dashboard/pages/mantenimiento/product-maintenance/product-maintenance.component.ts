import { Component, OnInit } from '@angular/core';
import { ProductResponse } from '@app/core/models/dashboard/mantenimiento/product/product-response';
import { ProductoService } from '@app/dashboard/services/mantenimineto/producto/producto.service';

@Component({
  selector: 'product-maintenance',
  templateUrl: './product-maintenance.component.html',
  styleUrl: './product-maintenance.component.scss'
})
export class ProductMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Producto';
  modalButtonText: string = 'Agregar';

  //Campos
  product:ProductResponse[] = [];
  constructor(private productService:ProductoService){

  }
  ngOnInit(): void {
    this.listarProducto();
  }

  //FUNCIONALIDAD
  listarProducto(){
    this.productService.getAll().subscribe(
      {
        next: (res: ProductResponse[])=>
          {
            this.product = res;
          }
      }
    );
  }
  //UI
  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Producto';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Producto';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.isModalOpen = false;
  }

  addProduct(): void {
    this.openDialog('add');
  }

  editProduct(): void {
    this.openDialog('edit');
  }

  deleteProduct(): void {
    // Lógica para eliminar producto
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de producto
    this.deleteProduct();
  }

  triggerFileInput(): void {
    const fileInput = document.getElementById('fileInput') as HTMLInputElement;
    fileInput.click();
  }

  handleFileInput(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const preview = document.querySelector('.upload-image-preview') as HTMLDivElement;
        preview.style.backgroundImage = `url(${e.target.result})`;
        preview.innerHTML = '';
      };
      reader.readAsDataURL(file);
    }
  }
}
