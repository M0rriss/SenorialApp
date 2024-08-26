import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ClienteResponse } from '@app/core/models/dashboard/clientes/cliente-response';
import { ClienteService } from '@app/dashboard/services/clientes/cliente/cliente.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'app-client-table',
  templateUrl: './client-table.component.html',
  styleUrl: './client-table.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class ClientTableComponent implements OnInit {
// Variables para la paginación
first: number = 0;
rows: number = 5;
totalRecords: number = 0;
//CLIENTE
customer : ClienteResponse [] = [];
constructor(
  private clienteService: ClienteService,
  private notificationService : NotificationService
){}
  ngOnInit(): void {
   this.listarClientesTodos();
  }

listarClientesTodos(){
  this.clienteService.getAll().subscribe({
    next:(res: ClienteResponse[]) =>{
      this.customer = res;
      this.totalRecords = res.length;
    },
    error: (err) => {
      this.notificationService.showError("Error al cargar los clientes");
    }
  });
}








onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  //this.listarClientes(); // Volver a cargar las categorías con la nueva página
}

}
