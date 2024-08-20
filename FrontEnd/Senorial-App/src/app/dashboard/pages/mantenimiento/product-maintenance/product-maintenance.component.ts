import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoriaResponse, CategoriasResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-response';
import { ProductDashResponse } from '@app/core/models/dashboard/mantenimiento/product/product-dash-response';
import { ProductEditRequest } from '@app/core/models/dashboard/mantenimiento/product/product-edit-request';
import { ProductResponse } from '@app/core/models/dashboard/mantenimiento/product/product-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { CategoriaService } from '@app/dashboard/services/mantenimineto/categorias/categoria.service';
import { ProductoService } from '@app/dashboard/services/mantenimineto/producto/producto.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';
import { PaginatorModule } from 'primeng/paginator';

@Component({
  selector: 'product-maintenance',
  templateUrl: './product-maintenance.component.html',
  styleUrl: './product-maintenance.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class ProductMaintenanceComponent implements OnInit {
  isModalOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  modalTitle: string = 'Agregar Producto';
  modalButtonText: string = 'Agregar';
  idProducto:number = 0;
 // Variables para la paginación
 first: number = 0;
 rows: number = 5;
 totalRecords: number = 0;
  //Campos
  product:GenericFilterResponse<ProductDashResponse> = {
    totalRegistros:0,
    lista:[],
  };
  formProduct:FormGroup;
  file:any = [];
  editar: boolean = false;
  categorias: CategoriasResponse[] = [];
  constructor(private productService:ProductoService,private fb:FormBuilder,
    private categoriService:CategoriaService,
    private notificationService: NotificationService,

  ){
    this.formProduct = this.fb.group({
      nombre: [],
      descripcion: [],
      idCategoria: [],
      derivar: [],
      precioVenta:[],
    })
  }
  ngOnInit(): void {
    this.listarProducto();
    this.listarTodasCategorias();
    //this.editarProducto();
  }

  //FUNCIONALIDAD
  listarTodasCategorias(){
    this.categoriService.listarTodasCategorias().subscribe({
      next: (res: CategoriasResponse[])=>{
        this.categorias = res;
      }
    });
  }
  listarProducto(page:number = 1, cantidad:number = 5){
    let req:GenericFilterRequest = {
      numeroPagina: page,
      cantidad: cantidad,
      filtros: [],
    }
    this.productService.listarProductos(req).subscribe(
      {
        next: (res: GenericFilterResponse<ProductDashResponse>)=>
          {
            this.product = res;
            this.totalRecords = res.totalRegistros;
          }
      }
    );
  }

  crearProducto(){
    let req = this.formProduct.value as ProductEditRequest;
    const formData = new FormData();
    formData.append("File",this.file);
    formData.append("Nombre",req.nombre);
    formData.append("Description",req.descripcion);
    formData.append("IdCategoria",req.idCategoria.toString());
    formData.append("Imprimir",req.derivar);
    formData.append("PrecioCompra",req.precioVenta.toString());
    this.productService.crearProducto(formData).subscribe({
      next: (res:CustomResponse)=>{
        this.notificationService.showSuccess( res.message ,'Producto creado');
        this.closeDialog();
      },
      error: () => {
        this.notificationService.showError('Error', 'Hubo un problema al crear el producto.');
      }
    });
  }
  productAcciones(){
    if(this.modalButtonText == "Agregar"){
      this.crearProducto();
    }
    else{
      this.editarProducto();
    }
  }
  editarProducto(){
    let req = this.formProduct.value as ProductEditRequest;
    const formData = new FormData();
    let archivo:File = this.file;
    let newFile = new File([],'');
    req.idProducto = this.idProducto

    formData.append("File",archivo);
    formData.append("IdProducto",req.idProducto.toString());
    formData.append("Nombre",req.nombre);
    formData.append("Description",req.descripcion);
    formData.append("IdCategoria",req.idCategoria.toString());
    formData.append("Imprimir",req.derivar);
    formData.append("PrecioCompra",req.precioVenta.toString());
    formData.append("Nuevo",`${this.editar}`);
    this.productService.editarProductos(formData).subscribe({
      next: (data:CustomResponse)=>{
        this.notificationService.showSuccess( data.message , 'Producto actualizado');
        this.closeDialog();

      },
      error: () => {
        this.notificationService.showError('Error', 'Hubo un problema al actualizar el producto.');
      }
    });
  }
  //UI
  openDialog(action: string): void {
    this.isModalOpen = true;
    if (action === 'add') {
      this.modalTitle = 'Agregar Producto';
      this.modalButtonText = 'Agregar';
    } else if (action === 'edit') {
      this.modalTitle = 'Editar Producto';
      this.modalButtonText = 'Guardar';
    }
  }

  closeDialog(): void {
    this.formProduct.reset();
    this.listarProducto();
    this.isModalOpen = false;
  }

  addProduct(): void {
    this.openDialog('add');
  }

  editProduct(req:ProductDashResponse): void {
    this.formProduct.patchValue({
      nombre: req.nombreProducto,
      descripcion: req.detalleProducto,
      idCategoria: req.idCategoria,
      derivar: req.derivar,
      precioVenta: req.precioVenta,
    })
    this.idProducto = req.idProducto;
    const preview = document.querySelector('.upload-image-preview') as HTMLDivElement;
    preview.style.backgroundImage = `url(${req.rutaImagen})`;
    preview.innerHTML = '';
    this.openDialog('edit');
  }

  deleteProduct(): void {
    // Lógica para eliminar producto
    this.isConfirmDialogOpen = false;
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog(): void {
    this.formProduct.reset();
    this.isConfirmDialogOpen = false;
  }

  confirmDelete(): void {
    // Lógica para confirmar eliminación de producto
    this.deleteProduct();

  }

  triggerFileInput(): void {
    const fileInput = document.getElementById('fileInput') as HTMLInputElement;
    fileInput.click();
  }

  handleFileInput(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const preview = document.querySelector('.upload-image-preview') as HTMLDivElement;
        preview.style.backgroundImage = `url(${e.target.result})`;
        preview.innerHTML = '';
      };
      reader.readAsDataURL(file);
    }
    //this.editar = true;
    this.file = file;
  }
  onPageChange(event: any) {
    this.first = event.first;
    this.rows = event.rows;
    this.listarProducto((this.first / this.rows)+1, this.rows);
  }
}
