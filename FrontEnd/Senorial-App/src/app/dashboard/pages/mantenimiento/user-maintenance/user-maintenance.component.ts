import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UsuarioAddRequest } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-add-request';
import { UsuarioEditRequest } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-edit-request';
import { UsuarioResponse } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-response';
import { RolResponse } from '@app/core/models/dashboard/roles/rol-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { UsuarioService } from '@app/dashboard/services/mantenimineto/usuario/usuario.service';
import { RolesService } from '@app/dashboard/services/roles/roles.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'user-maintenance',
  templateUrl: './user-maintenance.component.html',
  styleUrl: './user-maintenance.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class UserMaintenanceComponent implements OnInit {

  //FORM
  formUsuario:FormGroup;
  //Modal
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Usuario';
  modalButtonText: string = 'Agregar';
  isUserEnabled: boolean = true;
  confirmDialogDescription: string = '';
  confirmDialogTitle: string = '';
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
 roles: RolResponse[] = [];
 idUsuario:number = 0;
  constructor(
    private usuarioService:UsuarioService,
    private fb:FormBuilder,
    private rolService:RolesService,
    private notificationService: NotificationService,

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
    this.listarRoles();
  }

  //FUNCIONALIDAD
  listarRoles(){
    this.rolService.getAll().subscribe(
      {
        next: (res: RolResponse[])=>{
          this.roles = res;
        }
      }
    );
  }
  listarUsuarios(page:number = 1){
    let req:GenericFilterRequest = {
      numeroPagina:page,
      cantidad:this.rows,
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
    this.usuarioService.crearUsuario(req).subscribe({
      next: (res:CustomResponse)=>{
        this.notificationService.showSuccess(res.message,'Usuario creado');
        this.closeDialog();
      },
      error: (err) => {
        this.notificationService.showError('Error', 'Hubo un problema al crear el usuario.');
      }
    })
  }
  actulizarUsuario(){
    let req = this.formUsuario.value as UsuarioEditRequest
    req.file = this.file;
    req.idUsuario = this.idUsuario;
    req.nuevo = false;
    this.usuarioService.actulizarUsuario(req).subscribe({
      next: (res:CustomResponse)=>{
        this.notificationService.showSuccess( res.message ,'Usuario actualizado');
        this.closeDialog();
      },
      error: (err) => {
        this.notificationService.showError('Error', 'Hubo un problema al actualizar el usuario.');
      }
    })
    this.listarUsuarios();
  }
  accionesModal(){
    if(this.modalTitle == "Agregar Usuario"){
      this.crearNuevoUsuario();
    }
    else{
      this.actulizarUsuario();
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
    this.listarUsuarios();
    this.formUsuario.reset();
    this.isModalOpen = false;
  }

  addUser(): void {
    this.openDialog('add');
  }

  editUser(user: UsuarioResponse): void {
    this.idUsuario = user.idUsuario;
    this.formUsuario.patchValue({
      nombre:user.nombre,
      email: user.email,
      password: user.password,
      role: user.idRol,
      contact: user.telefono,
    });
    this.openDialog('edit');
  }

  deleteUser(): void {
    // Lógica para eliminar usuario
    this.isConfirmDialogOpen = false;
    this.notificationService.showSuccess('Usuario eliminado', 'El usuario fue eliminado exitosamente.');
  }

  openConfirmDialog(isEnabled: boolean): void {
    this.isUserEnabled = isEnabled;
  if (this.isUserEnabled) {
    this.confirmDialogTitle = '¿Quieres inhabilitar el usuario?';
    this.confirmDialogDescription = '¿Estás seguro que quieres inhabilitar a este usuario?';
  } else {
    this.confirmDialogTitle = '¿Quieres habilitar el usuario?';
    this.confirmDialogDescription = '¿Estás seguro que quieres habilitar a este usuario?';
  }
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
    this.listarUsuarios((this.first / this.rows)+1);
  }
}
