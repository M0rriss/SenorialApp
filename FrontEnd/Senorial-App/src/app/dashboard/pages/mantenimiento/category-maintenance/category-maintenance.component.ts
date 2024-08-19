import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../../../services/mantenimineto/categorias/categoria.service';
import { CategoriaResponse, CategoriasResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-response';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoriaRequest } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-request';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'category-maintenance',
  templateUrl: './category-maintenance.component.html',
  styleUrl: './category-maintenance.component.scss'
})
export class CategoryMaintenanceComponent implements OnInit{
  isTableView: boolean = true;
  isAddEditDialogOpen: boolean = false;
  isConfirmDialogOpen: boolean = false;
  dialogTitle: string = '';
  dialogActionButton: string = '';
  categoryName: string = '';
  subCategoryName: string = '';
  categoryStatus: boolean = true; // true = Activo, false = Inactivo
  selectedCategory: any = null;

  //variables locales
  categorias: CategoriaResponse[] = [];
  allCategorias: CategoriasResponse[]=[];

  categories = [
    { name: 'Categoria 1', subCategory: 'SubCategoria 1', active: true },
    { name: 'Categoria 2', subCategory: 'SubCategoria 2', active: true },
    // Agrega más categorías según sea necesario
  ];
 // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;

 //
 subCategoria: CategoriasResponse[] = [];
 formCategoria: FormGroup;
 idSubCategoria:number = 0;

  constructor(private categoriaService:CategoriaService,
    private fb:FormBuilder,
    private toastService:NotificationService
  ){
    this.formCategoria = this.fb.group({
      nombre: [],
      idCategoriaPadre: [],
    });
  }
  ngOnInit(): void {
    this.listarCategorias();
    this.listarAllCategorias();
    this.listarSubCategorias();
  }
  switchToTableView() {
    this.isTableView = true;
  }

  switchToVisualView() {
    this.isTableView = false;
  }

  openAddDialog() {
    this.dialogTitle = 'Agregar Categoría';
    this.dialogActionButton = 'Agregar';
    this.categoryName = '';
    this.subCategoryName = '';
    this.categoryStatus = true;
    this.isAddEditDialogOpen = true;
  }

  openEditDialog(category:any) {
    this.formCategoria.patchValue({
      nombre: category.nombre,
      idCategoriaPadre: category.idCategoriaPadre,
    })
    this.idSubCategoria = category.idCategoria;
    this.dialogTitle = 'Editar Categoría';
    this.dialogActionButton = 'Guardar';
    this.isAddEditDialogOpen = true;
  }

  closeAddEditDialog() {
    this.listarSubCategorias();
    this.listarCategorias();
    this.formCategoria.reset();
    this.isAddEditDialogOpen = false;
  }

  //FUNCIONALIDAD
  listarCategorias(){
    this.categoriaService.listarCategoria().subscribe({
      next: (res: CategoriaResponse[]) =>{
        this.categorias = res;
      }
    });
  }
  listarAllCategorias(){
    this.categoriaService.listarTodasCategorias().subscribe({
      next: (res: CategoriasResponse[]) =>{
        this.allCategorias = res;
      }
    });
  }

  listarSubCategorias(){
    this.categoriaService.listarSubCategoria().subscribe({
      next: (res: CategoriasResponse[]) =>{
        this.subCategoria = res;
      }
    })
  }


  agregarSubCategoria(){
    let req = this.formCategoria.value as CategoriaRequest
    this.categoriaService.crearSubCategoria(req).subscribe({
      next: (res:CustomResponse) => {
        alert(res.message);
        this.closeAddEditDialog();
      }
    })
  }

  editarSubCategoria(){
    let req = this.formCategoria.value as CategoriaRequest
    req.idCategoria = this.idSubCategoria;
    this.categoriaService.actulizarSubCategoria(req).subscribe({
      next: (res:CustomResponse) => {
        this.toastService.showSuccess("Test",res.message,false);
        alert(res.message);
        this.closeAddEditDialog();
      }
    })
  }
  saveCategory() {
    if (this.dialogActionButton === 'Agregar') {
      this.agregarSubCategoria();
    } else if (this.dialogActionButton === 'Guardar') {
      this.editarSubCategoria();
    }
    this.isAddEditDialogOpen = false;
  }
  //UI
  openConfirmDialog(category:any) {
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog() {
  
    this.isConfirmDialogOpen = false;
  }

  confirmDelete() {
    this.categories = this.categories.filter(cat => cat !== this.selectedCategory);
    this.isConfirmDialogOpen = false;
  }
// Método para manejar el cambio de página
onPageChange(event: any) {
  this.first = event.first;
  this.rows = event.rows;
  this.listarCategorias(); // Volver a cargar las categorías con la nueva página
}

}
