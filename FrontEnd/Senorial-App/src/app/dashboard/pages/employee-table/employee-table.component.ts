import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmpleadoRequest } from '@app/core/models/dashboard/empleados/empleado-request';
import { EmpleadoResponse } from '@app/core/models/dashboard/empleados/empleado-response';
import { RolResponse } from '@app/core/models/dashboard/roles/rol-response';
import { EmpleadoService } from '@app/dashboard/services/clientes/empleado/empleado.service';
import { RolesService } from '@app/dashboard/services/roles/roles.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class EmployeeTableComponent implements OnInit {
  isModalOpen: boolean = false;
  modalTitle: string = '';
  modalButtonText: string = '';
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;
idEmpleado: number = 0;
roles : RolResponse[] = [];
employees: EmpleadoResponse[] = [];
formEmployee:FormGroup;

constructor(
  private rolService:RolesService,
  private empleadoService:EmpleadoService,
  private fb:FormBuilder,
  private notificationService:NotificationService
){
  this.formEmployee = this.fb.group({
    nombres:        [],
    apellidos:      [],
    correo:         [],
    telefono:       [],
    identificacion: [],
    rol:            [],
    estado:         [],
  })
}

  ngOnInit(): void {
this.listarRoles();
this.listarEmpleados();
  }
  listarRoles() {
    this.rolService.getAll().subscribe({
      next: (res: RolResponse[]) => {
        this.roles = res;
      },
      error: () => {
        this.notificationService.showError('Error', 'Hubo un problema al listar los roles');
      }
    });
  }
listarEmpleados() {
  this.empleadoService.listarEmpleado().subscribe({
    next: (res: EmpleadoResponse[]) => {
      this.employees = res;
    },
    error: () => {
      this.notificationService.showError('Error', 'Hubo un problema al listar los empleados');
    }
  });
}
crearEmpleado() {
  const req = this.formEmployee.value as EmpleadoRequest;
  req.estado = this.formEmployee.get("estado")?.value == "true" ? true : false;
  req.idEmpleado = 0;
  this.empleadoService.crearEmpleado(req).subscribe({
    next: (res: EmpleadoResponse) => {
      this.notificationService.showSuccess('Éxito', 'Empleado creado');
      this.closeDialog();
      this.listarEmpleados();
    },
    error: () => {
      this.notificationService.showError('Error', 'Hubo un problema al crear el empleado');
    }
  });
}

editarEmpleado() {
  const req = this.formEmployee.value as EmpleadoRequest;
  req.estado = this.formEmployee.get("estado")?.value == "true" ? true : false;
  req.idEmpleado = this.idEmpleado;
  this.empleadoService.actualizarEmpleado(req).subscribe({
    next: (res: EmpleadoResponse) => {
      this.notificationService.showSuccess('Éxito', 'Empleado actualizado');
      this.closeDialog();
      this.listarEmpleados();
    },
    error: () => {
      this.notificationService.showError('Error', 'Hubo un problema al actualizar el empleado');
    }
  });
}
employeeAcciones() {
  if (this.modalButtonText === 'Agregar Empleado') {
    this.crearEmpleado();
  } else {
    this.editarEmpleado();
  }
}
onEstadoChange(empleado: EmpleadoResponse, event: Event) {
  const checkbox = event.target as HTMLInputElement;
  const nuevoEstado = checkbox.checked;

  // Actualizar el estado en la base de datos
  const req: EmpleadoRequest = {
    ...empleado,
    estado: nuevoEstado
  };

  this.empleadoService.actualizarEmpleado(req).subscribe({
    next: () => {
      this.notificationService.showSuccess('Éxito', 'Estado del empleado actualizado');
      empleado.estado = nuevoEstado;
    },
    error: () => {
      this.notificationService.showError('Error', 'Hubo un problema al actualizar el estado del empleado');
    }
  });
}
openDialog(action: string, empleado?: EmpleadoResponse): void {
  if (action === 'add') {
    this.modalTitle = 'Agregar Empleado';
    this.modalButtonText = 'Agregar Empleado';
    this.formEmployee.reset();
  } else if (action === 'edit' && empleado) {
    this.modalTitle = 'Editar Empleado';
    this.modalButtonText = 'Guardar Cambios';
    this.editEmployee(empleado);
  }
  this.isModalOpen = true;
}

editEmployee(empleado: EmpleadoResponse): void {
  this.formEmployee.patchValue({
    nombres: empleado.nombres,
    apellidos: empleado.apellidos,
    correo: empleado.correo,
    telefono: empleado.telefono,
    identificacion: empleado.identificacion,
    rol: empleado.rol,
    estado: empleado.estado
  });

  this.idEmpleado = empleado.idEmpleado;
}
  closeDialog(): void {
    this.isModalOpen = false;
  }
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    //this.listarEmpleados();
  }
}
