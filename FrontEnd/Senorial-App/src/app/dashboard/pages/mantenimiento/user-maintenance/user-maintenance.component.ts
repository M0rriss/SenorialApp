import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UsuarioAddRequest } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-add-request';
import { UsuarioResponse } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { UsuarioService } from '@app/dashboard/services/mantenimineto/usuario/usuario.service';

@Component({
  selector: 'user-maintenance',
  templateUrl: './user-maintenance.component.html',
  styleUrl: './user-maintenance.component.scss'
})
export class UserMaintenanceComponent implements OnInit {

  //FORM
  formUsuario:FormGroup;
  //Modal
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Usuario';
  modalButtonText: string = 'Agregar';
 // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;

 // status
 stateStatus:boolean = true;

 //CAMPOS
 usuario: GenericFilterResponse<UsuarioResponse> = {
  lista:[],
  totalRegistros:0
 }
 file:any;

  constructor(
    private usuarioService:UsuarioService,
    private fb:FormBuilder
  ){
    this.formUsuario = this.fb.group({
      nombre:[],
      email: [],
      password: [],
      role: [],
      contact: [],
    });
  }
  ngOnInit(): void {
    this.listarUsuarios();
  }
  //FUNCIONALIDAD
  listarUsuarios(){
    let req:GenericFilterRequest = {
      numeroPagina:1,
      cantidad:5,
      filtros:[],
    }
    this.usuarioService.listarUsuarios(req).subscribe({
      next: (data: GenericFilterResponse<UsuarioResponse>)=>{
        this.usuario = data;
      },
    })
  }
  crearNuevoUsuario(){
    let req = this.formUsuario.value as UsuarioAddRequest
    req.file = this.file;
    console.log(req);
    this.usuarioService.crearUsuario(req).subscribe({
      next: (res:CustomResponse)=>{
        alert(res.message);
      }
    })
  }
  accionesModal(){
    if(this.modalTitle == "Agregar Usuario"){
      this.crearNuevoUsuario();
    }
  }
  //UI
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
    this.formUsuario.patchValue({
      nombre:"",
      email: "",
      password: "",
      role: "",
      contact: "",
    });
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
    this.file = file;
  }
    // Método para manejar el cambio de página
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;

  }
}
