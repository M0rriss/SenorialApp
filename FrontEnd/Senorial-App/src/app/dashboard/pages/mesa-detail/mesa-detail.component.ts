import { Location } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { DetalleMesaResponse } from '@app/core/models/dashboard/local/detalle/detalle-mesa-response';
import { LocalMesaResponse } from '@app/core/models/dashboard/local/local-mesa-response';
import { MesaslocalService } from '@app/dashboard/services/local-mesa/mesaslocal.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'mesa-detail',
  templateUrl: './mesa-detail.component.html',
  styleUrl: './mesa-detail.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class MesaDetailComponent implements OnInit{
  selectedReceiptOption: string = 'Boleta';

  mesaDetalle : DetalleMesaResponse[] = [];
  idMesa: number = 0;
  idPedido: number = 0;

  local: LocalMesaResponse = {
  idPedido:  0,
  idMesa:    0,
  nombre:   '',
  precio:   0,
  cantidad: 0,
  estado:   0
  }

  constructor(
    private mesaslocalService : MesaslocalService,
    private router:Router,
    private location: Location,
    private notification :NotificationService
  ){

  }
  ngOnInit(): void {
    const state = this.location.getState() as { mesa: LocalMesaResponse };
    if (state && state.mesa) {
      this.local = state.mesa;
      this.listadoDetallado(this.local.idMesa, this.local.idPedido);
    } else {
      this.notification.showWarn('Warn', 'Tiene que seleccionar una mesa.');

      this.router.navigate(['dashboard']);
    }
  }

  listadoDetallado(idMesa: number, idPedido: number){
    this.mesaslocalService.listarDetalleProductosMesas$(idMesa, idPedido).subscribe({
      next: (data: DetalleMesaResponse[]) =>{
        this.mesaDetalle = data;
      }
    });
  }


  selectOption(option: string): void {
    this.selectedReceiptOption = option;
  }



}
