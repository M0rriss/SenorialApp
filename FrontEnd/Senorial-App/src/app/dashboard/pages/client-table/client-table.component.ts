import { Component } from '@angular/core';

@Component({
  selector: 'app-client-table',
  templateUrl: './client-table.component.html',
  styleUrl: './client-table.component.scss'
})
export class ClientTableComponent {
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;

onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  //this.listarClientes(); // Volver a cargar las categorías con la nueva página
}

}
