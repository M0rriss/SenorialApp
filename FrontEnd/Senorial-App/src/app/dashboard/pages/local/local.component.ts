import { Component } from '@angular/core';

@Component({
  selector: 'app-local',
  templateUrl: './local.component.html',
  styleUrl: './local.component.scss'
})
export class LocalComponent {
// Variables para la paginación
first: number = 0;
rows: number = 10;
totalRecords: number = 0;
onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  //this.listarEmpleados();
}
}
