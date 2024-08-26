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
listarRoles(){
  this.rolService.getAll().subscribe(
    {
      next: (res: RolResponse[])=>{
        this.roles = res;
      }
    }
  );
}
listarEmpleados(){
  this.empleadoService.listarEmpleado().subscribe({
    next: (res: EmpleadoResponse[])=>{
      this.employees=res;
    },
    error: () => {
      this.notificationService.showError('Error', 'Hubo un problema al listar los empleados');
    }
  })
}
crearEmpleado() {
  const req = this.formEmployee.value as EmpleadoRequest;
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
  if (this.modalButtonText === "Agregar") {
    this.crearEmpleado();
  } else {
    this.editarEmpleado();
  }
}
// editEmployee(empleado: EmpleadoResponse): void {
//   this.formEmployee.patchValue({
//     nombres: empleado.nombres,
//     apellidos: empleado.apellidos,
//     correo: empleado.correo,
//     telefono: empleado.telefono,
//     identificacion: empleado.identificacion,
//     rol: empleado.rol,
//     estado: empleado.estado
//   });

//     this.idEmpleado = empleado.idEmpleado;
//     this.openDialog('edit');

// }




openDialog(action: string, empleado?: EmpleadoResponse): void {
  console.log(action)
  if (action === 'add') {
    this.modalTitle = 'Agregar Empleado';
    this.modalButtonText = 'Agregar Empleado';
    this.formEmployee.reset();
  } else if (action === 'edit' && empleado) {
    this.modalTitle = 'Editar Empleado';
    this.modalButtonText = 'Guardar Cambios';
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
  this.isModalOpen = true;
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
