import { Component, OnInit } from '@angular/core';
import { MesaResponse } from '@app/core/models/dashboard/mantenimiento/mesas/mesa-response';
import { MesaService } from '@app/dashboard/services/mantenimineto/mesa/mesa.service';
import { PusherService } from '@app/ecommerce/services/pusher/pusher.service';

@Component({
  selector: 'app-local',
  templateUrl: './local.component.html',
  styleUrl: './local.component.scss'
})
export class LocalComponent implements OnInit {
  constructor(
    private pusherService: PusherService,
    private mesaService: MesaService
  ){}
ngOnInit(): void {
  console.log("second")
    this.pusherService.bindEvent('my-event', (data: any) => {
      console.log("Evento recibido:", data);
      this.MesasWebSockets = data;
      console.log("data",data)
      this.cruzado = this.actualizarEstadoMesas(this.MesasApi, this.MesasWebSockets);
      // Puedes manejar la data recibida aquí
    });
    this.listarMesas();
}
listarMesas(){
  this.mesaService.getAll()
  .subscribe({
    next: (data: MesaResponse[])=>{
      this.MesasApi = data;
      this.cruzado = this.actualizarEstadoMesas(this.MesasApi, this.MesasWebSockets);

    }
  });
}

//variables
MesasApi: any[]=[];
MesasWebSockets: any[]= [];
cruzado: any []=[];
 actualizarEstadoMesas(mesasApi: any[], mesasWebSocket: any[]): any[] {
  return mesasApi.map(mesaApi => {
      const mesaWebSocket = mesasWebSocket.find(wsMesa => wsMesa.idMesa === mesaApi.idMesa);

      if (mesaWebSocket) {
          // Actualizar el estado de la mesa de la API con el estado del websocket
          return {
              ...mesaApi,
              estado: mesaWebSocket.estado
          };
      }

      // Si no se encuentra la mesa en el websocket, devolver la mesa de la API sin cambios
      return mesaApi;
  });
}
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
