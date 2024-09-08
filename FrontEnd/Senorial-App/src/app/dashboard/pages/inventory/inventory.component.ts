import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EntradaRequest } from '@app/core/models/dashboard/entrada/entrada-request';
import { BusqueInventarioInsumoResponse } from '@app/core/models/dashboard/Inventario/busqueda-inventario-insumo-response';
import { InventarioDetalleResponse } from '@app/core/models/dashboard/Inventario/inventario-detalle-response';
import { InventarioResponse } from '@app/core/models/dashboard/Inventario/inventario-response';
import { SalidaRequest } from '@app/core/models/dashboard/salida/salida-request';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { EntradaService } from '@app/dashboard/services/entrada/entrada.service';
import { InventoryService } from '@app/dashboard/services/inventory/inventory.service';
import { SalidaService } from '@app/dashboard/services/salida/salida.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

// Interfaz para representar un ítem de inventario
interface InventoryItem {
  name: string;
  unit: string;
  stock: number;
  disponibilidad?: string;
  precioCompra?: string;
  precioVenta?: string;
}

@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class InventoryComponent implements OnInit {
  // Variables para la paginación
  first: number = 0;
  rows: number = 5;
  first2: number = 0;
  rows2: number = 5;
  totalRecords: number = 0;

  // Variables para manejar los diálogos modales
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Editar el Detalle';
  modalButtonText: string = 'Editar';
  selectedItem: InventarioDetalleResponse | null = null;

  // Variables para manejar los diálogos de entradas y salidas
  isEntryDialogOpen = false;
  isExitDialogOpen = false;

  // Variable para mostrar el detalle del stock
  isStockDetailVisible = false;

  // Formulario reactivo para editar los detalles del inventario
  formDetalle: FormGroup;



  formBuscar: FormGroup;
  formEntrada:FormGroup;
  formSalida:FormGroup;
  // Constructor para inicializar el formulario
  constructor(private fb: FormBuilder,
    private InventarioServicio: InventoryService,
    private entradaService:EntradaService,
    private salidaService:SalidaService,
    private notificationService: NotificationService
  ) {
    this.formDetalle = this.fb.group({
      descripcion: [],
      stock: [],
      precioCompra: [],
      precioVenta: [],
    });
    this.formBuscar = this.fb.group({
      insumo:[],
    });
    this.formEntrada = this.fb.group({
      cantidad:[],
      precioCompra:[],
    });
    this.formSalida = this.fb.group({
      cantidad:[],
      motivo:[]
    })
  }
  ngOnInit(): void {
    this.listarInventario();
    this.listarInventarioDetalle();
    this.listadoInsumos();
  }
  //Campos
  inventarioInsumos:InventarioDetalleResponse[] = [];
  invertario: GenericFilterResponse<InventarioResponse> = {lista:[],totalRegistros:0};
  inventarioDetalle: GenericFilterResponse<InventarioDetalleResponse> = {lista:[],totalRegistros:0};
  busquedaInsumo: BusqueInventarioInsumoResponse = {
idInsumo:0,
idInventario:0,
nombre:'',
stockTotal:0
  };
  nombreInsumo: string = '';

  idInsumo: number = 0;
  //Funcionalidad
  listarInventario(insumo:string = ''){
    this.InventarioServicio.listarInventario((this.first / this.rows)+1,this.rows,insumo).subscribe({
      next: (res:GenericFilterResponse<InventarioResponse>)=>{
        this.invertario = res;
      }
    });
  }
  listarInventarioDetalle(){
    this.InventarioServicio.listarInventarioDetalle((this.first2/this.rows2)+1,this.rows2,'').subscribe({
      next: (res:GenericFilterResponse<InventarioDetalleResponse>)=>{
        this.inventarioDetalle = res;
      }
    });
   /*  this.InventarioServicio.listarInventarioDetalle(1,1000,'').subscribe({
      next: (res:GenericFilterResponse<InventarioDetalleResponse>)=>{
        this.inventarioDetalle = res;
      }
    }); */

  }
  //LISTADO PARA ENTRADAS Y SALIDAS DE LOS INSUMOS
  listadoInsumos(){
    this.InventarioServicio.listarInventarioDetalle(1, 1000, '').subscribe({
      next: (res: GenericFilterResponse<InventarioDetalleResponse>) => {
        this.inventarioInsumos = res.lista; // Asigna la lista de insumos
      },
    });
  }

  buscarInventarioInsumo(){
    this.idInsumo= +this.formBuscar.get('insumo')?.value;

    this.InventarioServicio.buscarInsumoInvetario(this.idInsumo).subscribe({
      next: (res:BusqueInventarioInsumoResponse)=>{
        this.busquedaInsumo = res;
      }
    })
  }

  agregarEntrada(){
    let req: EntradaRequest ={
      cantidad : +this.formEntrada.get('cantidad')?.value,
      precioCompra : +this.formEntrada.get('precioCompra')?.value,
      idInsumo: this.idInsumo,
      idInventario: 1,
    };

    this.entradaService.registarEntrada(req).subscribe({
      next: (res:CustomResponse)=>{
        this.notificationService.showContrast('Entrada registrada','Exito');
        this.formEntrada.reset();
        this.closeDialog();
      },
      error: (err) => {
          this.notificationService.showError('Error al registrar la entrada', 'Error');
      }
    });
  }

  agregarSalida(){
    let req: SalidaRequest ={
      cantidad : +this.formSalida.get('cantidad')?.value,
      motivo : this.formSalida.get('motivo')?.value,
      idInsumo: this.idInsumo,
      idInventario: 1,
    }
    this.salidaService.registarSalida(req).subscribe({
      next:(res:CustomResponse)=>{
        this.notificationService.showContrast('Salida registrada','Exito');
        this.formEntrada.reset();
        this.closeDialog();
      },
      error: (err) => {
          this.notificationService.showError('Error al registrar la salida', 'Error');
      }
    })
  }

  eliminarInsumoInventario(idInsumo:number){
    this.InventarioServicio.eliminarInsumoInventario(idInsumo).subscribe({
      next:(res:CustomResponse)=>{

      }
    })
  }

  filtrarlistaInventario(){

  }

  // Método para abrir el diálogo de edición
  openEditDialog(item: InventarioDetalleResponse) {
    this.selectedItem = item; // Guarda el ítem seleccionado para editar
    this.formDetalle.patchValue({
      descripcion: item.nombre,
      stock: item.stoct,
      // Ajusta aquí los valores para precioCompra y precioVenta si están en tu InventoryItem
    });
    this.modalTitle = 'Editar el Detalle';
    this.modalButtonText = 'Guardar Cambios';
    this.isModalOpen = true;
  }

  // Método para abrir el diálogo de confirmación de eliminación
  openDeleteDialog(item: InventarioDetalleResponse) {
    this.selectedItem = item; // Guarda el ítem seleccionado para eliminar
    this.isConfirmDialogOpen = true;
  }

  // Método para confirmar la eliminación
  confirmDelete(): void {
    if (this.selectedItem) {
      // Lógica para eliminar el ítem seleccionado
      this.eliminarInsumoInventario(this.selectedItem.idInsumo);
      this.listarInventarioDetalle();
      console.log('Eliminando', this.selectedItem.nombre);
      // Aquí agregarías la lógica real para eliminar el ítem de la base de datos o el estado
    }
    this.isConfirmDialogOpen = false;
  }

  // Método para cerrar diálogos modales
  closeDialog() {
    this.listarInventario();
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = false;
    this.selectedItem = null;
    this.isModalOpen = false;
    this.isConfirmDialogOpen = false;
  }
 // Método para cerrar el diálogo de confirmación
 closeConfirmDialog(): void {
  this.isConfirmDialogOpen = false;
}
  // Método para abrir el diálogo de entrada
  openEntryDialog() {
    this.isEntryDialogOpen = true;
    this.isExitDialogOpen = false;
  }

  // Método para abrir el diálogo de salida
  openExitDialog() {
    this.isEntryDialogOpen = false;
    this.isExitDialogOpen = true;
  }

  // Método para realizar una búsqueda en el inventario
  onSearch(event: Event) {
    const query = (event.target as HTMLInputElement).value.toLowerCase();
    //this.selectedItem = this.inventory.find(item => item.name.toLowerCase().includes(query)) || null;
  }

  // Método para mostrar el detalle del stock
  showStockDetail() {
    this.listarInventarioDetalle();
    this.isStockDetailVisible = true;
  }

  // Método para ocultar el detalle del stock
  hideStockDetail() {
    this.isStockDetailVisible = false;
  }

  // Método para obtener la disponibilidad del stock
  getDisponibilidad(stock: number): string {
    if (stock > 18) {
      return 'Suficiente';
    } else if (stock < 19 && stock > 11){
      return 'En-Proceso';
    } else {
      return 'Agotados';
    }
  }

  // Método para obtener la clase CSS según la cantidad de stock
  getStatusClass(stock: number): string {
    if (stock > 18) {
      return 'status-sufficient';
    } else if (stock < 19 && stock > 11) {
      return 'status-processing';
    } else {
      return 'status-out-of-stock';
    }
  }

  // Método para manejar el cambio de página en la paginación
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    this.listarInventario();
    // Aquí iría la lógica para manejar el cambio de página
  }
  onPageChange2(event: any) {
    this.first2 = event.first;
    this.rows2 = event.rows;
     this.listarInventarioDetalle();
    // Aquí iría la lógica para manejar el cambio de página
  }

  // Método para manejar las acciones del detalle, como guardar cambios
  detalleAcciones() {
    // Lógica para manejar las acciones del detalle
    console.log('Guardando cambios para:', this.formDetalle.value);
    this.closeDialog(); // Cierra el diálogo después de guardar
  }
}
