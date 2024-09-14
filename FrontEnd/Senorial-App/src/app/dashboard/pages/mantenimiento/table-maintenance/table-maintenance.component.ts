import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MesaRequest } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-request';
import { MesaResponse } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-response';
import { MesaService } from '@app/dashboard/services/mantenimineto/mesa/mesa.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'table-maintenance',
  templateUrl: './table-maintenance.component.html',
  styleUrl: './table-maintenance.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class TableMaintenanceComponent implements OnInit {
  mesas = [
    { name: 'Mesa 1', active: true },
    { name: 'Mesa 2', active: false },
    { name: 'Mesa 3', active: true },
    { name: 'Mesa 4', active: true }
  ];

  isAddEditDialogOpen = false;
  isConfirmDialogOpen = false;
  dialogTitle = 'Add Mesas';
  dialogActionButton = 'Add Mesas';

  mesaName = '';
  mesaStatus = '';
  selectedMesa: any = null;

  //MESAS
  mesasList:MesaResponse[] = [];
  formMesa:FormGroup;
  idMesa: number = 0;
  constructor(private mesaService:MesaService,
    private fb:FormBuilder,
    private notificationService: NotificationService,

  ){
    this.formMesa = this.fb.group({
      nombre:[],
      estado:[]
    })
  }
  ngOnInit(): void {
    this.listarMesas();
  }

  //FUNCIONAMINETO
  // listarMesas(){
  //   this.mesaService.getAll()
  //     .subscribe({
  //       next: (data: MesaResponse[])=>{
  //         this.mesasList = data;
  //       }
  //     });
  // }
  listarMesas(): void {
    this.mesaService.getAll().subscribe({
      next: (data) => {
        this.mesasList = data.map(mesa => ({
          ...mesa,
          estado: mesa.estado || 'Inactivo'  // Asegúrate de que el estado esté siempre definido
        }));
      },
      error: () => {
        this.notificationService.showError('Error', 'No se pudieron cargar las mesas.');
      }
    });
  }
  crearMesa(){
    let req = this.formMesa.value as MesaRequest;
    req.idMesa=0;
    this.mesaService.crearRegistro(req).subscribe({
      next: (res: MesaResponse)=>{
        this.notificationService.showSuccess('Mesa creada exitosamente', "Exito");
        this.closeAddEditDialog();
      },
      error: () => {
        this.notificationService.showError('Error', 'Hubo un problema al crear la mesa.');
      }
    });
  }
  editarMesa(){
    let req = this.formMesa.value as MesaRequest;
    req.idMesa = this.idMesa;
    this.mesaService.actulizarRegistro(req).subscribe({
      next: (res: MesaResponse)=>{
        this.notificationService.showSuccess('Mesa actualizada exitosamente');
        this.closeAddEditDialog();
      },
      error: () => {
        this.notificationService.showError('Error', 'Hubo un problema al actualizar la mesa.');
      }
    });
  }
  // Abrir diálogo de agregar mesa
  openAddDialog() {
    this.dialogTitle = 'Add Mesas';
    this.dialogActionButton = 'Add Mesas';
    this.mesaName = '';
    this.mesaStatus = '';
    this.selectedMesa = null;
    this.isAddEditDialogOpen = true;
  }

  // Abrir diálogo de editar mesa
  openEditDialog(mesa: any) {
    this.formMesa.patchValue({
      nombre: mesa.nombre,
      estado: mesa.estado
    });
    this.idMesa = mesa.idMesa;
    this.dialogTitle = 'Edit Mesas';
    this.dialogActionButton = 'Save Changes';
    this.mesaName = mesa.name;
    this.mesaStatus = mesa.active ? 'Active' : 'Inactive';
    this.selectedMesa = mesa;
    this.isAddEditDialogOpen = true;
  }

  // Guardar mesa (agregar o editar)
  saveMesa() {
    if (this.selectedMesa == null) {
      this.crearMesa()
      // Editar mesa existente
      this.selectedMesa.name = this.mesaName;
      this.selectedMesa.active = this.mesaStatus === 'Active';
    } else {
      this.editarMesa();
      // Agregar nueva mesa
      this.mesas.push({
        name: this.mesaName,
        active: this.mesaStatus === 'Active'
      });
    }
    this.isAddEditDialogOpen = false;
  }

  // Cerrar diálogo de agregar/editar
  closeAddEditDialog() {
    this.listarMesas();
    this.formMesa.reset();
    this.isAddEditDialogOpen = false;
  }

  // Abrir diálogo de confirmación de eliminación
  openConfirmDialog(mesa: any) {
    this.selectedMesa = mesa;
    this.isConfirmDialogOpen = true;
  }

  // Confirmar eliminación de mesa
  confirmDelete() {
    this.mesas = this.mesas.filter(m => m !== this.selectedMesa);
    this.isConfirmDialogOpen = false;
    this.selectedMesa = null;
  }

  // Cerrar diálogo de confirmación
  closeConfirmDialog() {
    this.isConfirmDialogOpen = false;
    this.selectedMesa = null;
  }
  toggleEstado(mesa: MesaResponse, event: Event): void {
    const input = event.target as HTMLInputElement;
    const nuevoEstado = input.checked ? 'Activo' : 'Inactivo';

    // Prepara el objeto de actualización
    const mesaActualizada = { ...mesa, estado: nuevoEstado };

    // Realiza la llamada al backend para actualizar el estado
    this.mesaService.actulizarRegistro(mesaActualizada).subscribe({
      next: (response) => {
        // Verifica si la respuesta del backend contiene la información actualizada
        if (response.estado === nuevoEstado) {
          this.notificationService.showSuccess('Estado actualizado exitosamente');
          // Actualiza el estado en la interfaz de usuario
          mesa.estado = nuevoEstado;
        } else {
          // Restaura el estado visual si la actualización no fue exitosa
          input.checked = (mesa.estado === 'Activo');
          this.notificationService.showError('Error', 'El estado no se actualizó correctamente.');
        }
      },
      error: () => {
        // Restaura el estado visual si ocurre un error
        input.checked = (mesa.estado === 'Activo');
        this.notificationService.showError('Error', 'Hubo un problema al actualizar el estado.');
      }
    });
  }
}
