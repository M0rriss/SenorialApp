import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CategoriaEcommerceResponse } from '@app/core/models/dashboard/mantenimiento/categoria/categoria-ecommerce-response';
import { CategoriaService } from '@app/dashboard/services/mantenimineto/categorias/categoria.service';

@Component({
  selector: 'ecommerce-categories-bar',
  templateUrl: './categories-bar.component.html',
  styleUrl: './categories-bar.component.scss'
})
export class CategoriesBarComponent implements OnInit{

  @Output() enviarFiltro = new EventEmitter<number>();
  @Output() enviarSub = new EventEmitter<number>();

  categoria: CategoriaEcommerceResponse[] = [];
  subCategoria: CategoriaEcommerceResponse[] = [];
  submentu: boolean = false;
  rutaImge: string[] = [
    "./hamburguesa.svg",
    "./pollo-frito-.svg",
    "./platosFondo.svg",
    "./salud.svg",
    "./papasFritas.svg",
  ];
  constructor(private categoriaService:CategoriaService){

  }
  ngOnInit(): void {
    this.listarCategoria();
  }

  listarCategoria(){
    this.categoriaService.listarEcommerCategoria()
    .subscribe({
      next: (res:CategoriaEcommerceResponse[])=>{
        let index = 0;
        for(var r of res){
          r.ruta = this.rutaImge[index];
          index++;
        }
        this.categoria = res;
      }
    });
  }
  listarSubCategoria(idCategoria:number){
    this.categoriaService.buscarSubCategoria(idCategoria).subscribe({
      next: (res:CategoriaEcommerceResponse[])=>{
        this.subCategoria = res;
      }
    });
  }
  enviarInfo(idCategoria:number){
    this.submentu = true;
    this.listarSubCategoria(idCategoria);
    this.enviarFiltro.emit(idCategoria);
  }
  enviarSubCategoria(idCategoria:number){
    this.enviarSub.emit(idCategoria);
  }

}
