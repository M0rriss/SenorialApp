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

// areas = ["piso 1", "piso 2", "patio"];
// mesas: any[] = [];
// constructor(
//   private mesaService: MesasService,
//   ){}

// ngOnInit(): void {
//   /*this.mesaService.getMesasByArea('piso 1').subscribe({
//     next: (data) => console.log(data)
//   });*/
//   this.getMesas(this.areas[0]);
// }
// ngOnInit(): void {
//   // Leer las mesas desde Backend C#
//   this.getMesasApi().subscribe({
//       next: (data) => {
//           this.mesas = data;
//           this.getMesasRT().subscribe({
//               // Llamas al realtime
//               const mesasRt = [{ mid: 1, st: 3 }, { mid: 2, st: 0 }];
//               for (const mesa of this.mesas) {
//                   mesa.estado = mesasRt.find(m => m.mid == mesa.id)?.st ?? mesa.estado;
//               }
//           });
//       }
//   });

//   this.getMesas(this.areas[0]);
//}

// changeArea(event: any) {
//   let value = event.target.value;
//   console.log('mesa:', value);

//   this.getMesas(value);
// }

// getMesas(area: string) {
//   this.mesaService.getMesasByArea(area).subscribe({
//     next: (data) => {
//       console.log(data);
//       this.mesas = data;
//     }
//   });
// }

// changeEstado(mesa: any, newState: string) {
//   mesa.estado = newState;
//   this.mesaService.updateMesa(mesa);
// }

// updateMesaImagen(mesa:any, event: any) {
//   const files: {[key: string]: File} = event.target.files;
//   // {'archivo.jpg': FILE}
//   if(!files[0]) return;

//   const fileName = `mesa-${mesa.id}`;
//   const ref = this.mesaService.uploadMesaImagenRef(fileName);
//   const task = this.mesaService.uploadMesaImagen(fileName, files[0]);
//   task.percentageChanges().subscribe({
//     next: (data)=> console.log('percent', data),
//   });
//   task.snapshotChanges().pipe(
//     tap(console.log),
//     finalize(
//       () => ref.getDownloadURL().subscribe(
//         URL => this.updateImage(mesa, URL)
//       )
//     ),
//   ).subscribe();
// }
// updateImage(mesa: any, image: string){
//   mesa.foto = image;
//   this.mesaService.updateMesa(mesa);
// }

}
