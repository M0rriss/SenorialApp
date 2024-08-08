import { Component } from '@angular/core';

@Component({
  selector: 'user-maintenance',
  templateUrl: './user-maintenance.component.html',
  styleUrl: './user-maintenance.component.scss'
})
export class UserMaintenanceComponent {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Usuario';
  modalButtonText: string = 'Agregar';

  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Usuario';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Usuario';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.isModalOpen = false;
  }

  addUser(): void {
    this.openDialog('add');
  }

  editUser(): void {
    this.openDialog('edit');
  }

  deleteUser(): void {
    // Lógica para eliminar usuario
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de usuario
    this.deleteUser();
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
