import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../../../services/mantenimineto/categorias/categoria.service';
import { CategoriaResponse, CategoriasResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-response';

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

  constructor(private categoriaService:CategoriaService){}
  ngOnInit(): void {
    this.listarCategorias();
    this.listarAllCategorias();
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
    this.dialogTitle = 'Editar Categoría';
    this.dialogActionButton = 'Guardar';
    this.categoryName = category.name;
    this.subCategoryName = category.subCategory;
    this.categoryStatus = category.active;
    this.selectedCategory = category;
    this.isAddEditDialogOpen = true;
  }

  closeAddEditDialog() {
    this.isAddEditDialogOpen = false;
  }
  
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

  saveCategory() {
    if (this.dialogActionButton === 'Agregar') {
      this.categories.push({
        name: this.categoryName,
        subCategory: this.subCategoryName,
        active: this.categoryStatus
      });
    } else if (this.dialogActionButton === 'Guardar') {
      this.selectedCategory.name = this.categoryName;
      this.selectedCategory.subCategory = this.subCategoryName;
      this.selectedCategory.active = this.categoryStatus;
    }
    this.isAddEditDialogOpen = false;
  }

  openConfirmDialog(category:any) {
    this.selectedCategory = category;
    this.isConfirmDialogOpen = true;
  }

  closeConfirmDialog() {
    this.isConfirmDialogOpen = false;
  }

  confirmDelete() {
    this.categories = this.categories.filter(cat => cat !== this.selectedCategory);
    this.isConfirmDialogOpen = false;
  }

  
}
