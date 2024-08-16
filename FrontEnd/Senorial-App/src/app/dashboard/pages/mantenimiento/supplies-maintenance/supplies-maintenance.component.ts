import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FiltroInsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/filtro-insumo-response';
import { InsumoRequest } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-request';
import { InsumoResponse } from '@app/core/models/dashboard/mantenimiento/insumos/insumo-response';
import { UnidadResponse } from '@app/core/models/dashboard/unidad/unidad-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { InsumoService } from '@app/dashboard/services/mantenimineto/insumos/insumo.service';
import { UnidadService } from '@app/dashboard/services/unidad/unidad.service';

@Component({
  selector: 'supplies-maintenance',
  templateUrl: './supplies-maintenance.component.html',
  styleUrl: './supplies-maintenance.component.scss'
})
export class SuppliesMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Insumo';
  modalButtonText: string = 'Agregar';
 // Variables para la paginación
 first: number = 0;
 rows: number = 5;
 totalRecords: number = 0;
  //SUMINISTRO
  formInsumo:FormGroup;
  suministro: GenericFilterResponse<FiltroInsumoResponse> = {
    totalRegistros:0,
    lista:[]
  };
  unidad:UnidadResponse[] = [];
  length = this.suministro.totalRegistros / 5;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  
  idInsumo:number = 0;
  constructor(private insumoService:InsumoService,
    private fb:FormBuilder,
    private unidaService:UnidadService
  ){
    this.formInsumo = this.fb.group({
      nombre : [],
      idUnidad : [],
    });
  }
  ngOnInit(): void {
    this.listarUnidades();
    this.filtrarSuministro();
  }

  //FUNCIONAMIENTO
  filtrarSuministro(pagina:number = 1, cantidad:number = 5){
    let req: GenericFilterRequest = {
      numeroPagina:pagina,
      cantidad:cantidad,
      filtros:[],
    }
    this.insumoService.filtrarInsumos(req)
      .subscribe({
        next: (res: GenericFilterResponse<FiltroInsumoResponse>)=>{
          this.suministro = res;
        }
      });
  }

  
  agregarInsumo(){
    let req = this.formInsumo.value as InsumoRequest;
    req.idInsumo = 0;
    req.url= "";

    this.insumoService.crearInsumo(req)
    .subscribe({
      next: (res: CustomResponse) => {
        alert(res.message);
      }
    });
  }
  actuliarInsumo(){
    let req = this.formInsumo.value as InsumoRequest;
    req.idInsumo = this.idInsumo;
    req.url= "";

    this.insumoService.actulizarInsumo(req)
    .subscribe({
      next: (res: CustomResponse) => {
        alert(res.message);
      }
    });
  }
  eliminarInsumo(idInsumo:number){
    this.insumoService.eliminarInsumo(idInsumo)
      .subscribe({
        next: (res: boolean)=>{
          console.log(res);
        }
      });
  }
  listarUnidades(){
    this.unidaService.listarUnidades().subscribe({
      next: (res:UnidadResponse[])=>{
        this.unidad = res;
      }
    });
  }
  //UI
  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Insumo';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Insumo';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.formInsumo.reset();
    this.filtrarSuministro();
    this.isModalOpen = false;
  }

  addInsumo(): void {
    this.openDialog('add');
  }

  editInsumo(insumo:InsumoResponse): void {
    this.formInsumo.patchValue({
      nombre : insumo.insumoNombre,
      idUnidad : insumo.unidadMedida,
    });
    this.idInsumo = insumo.idInsumo;
    this.openDialog('edit');
  }

  deleteInsumo(): void {
    // Lógica para eliminar insumo
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de insumo
    this.deleteInsumo();
  }
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    this.filtrarSuministro((this.first/this.rows)+1,this.rows);
  }
}
