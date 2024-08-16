import { Component, OnInit } from '@angular/core';
import { CardProductResponse } from '@app/core/models/ecommerce/components/card-product/card-product-response';
import { GenericFilterRequest } from '@app/core/models/generic/generic-filter-request';
import { GenericFilterResponse } from '@app/core/models/generic/generic-filter-response';
import { LocalComponent } from '@app/dashboard/pages/local/local.component';
import { CardProductService } from '@app/ecommerce/service/components/card-product/card-product.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'ecommerce-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit{
  // Variables para la paginación
 first: number = 0;
 rows: number = 10;
 totalRecords: number = 0;

 fitro1:number = 0;
 fritro2:number = 0;



  products: GenericFilterResponse<CardProductResponse> = {
    lista: [],
    totalRegistros: 0,
  };
  list: CardProductResponse[] = [];
  constructor(private cardProductService:CardProductService){}
  ngOnInit(): void {
    this.listarProductos();
  }

  optenerFiltro(data:number){
    this.fitro1 = data;
    this.listarProductos(data.toString());
  }
  recibirSubCategoria(data:number){
    this.fritro2= data;
    this.listarProductos("",data.toString());
  }

  listarProductos(idCategoria:string = "",idSubCategoria:string="",page:number = 0):void{
    let req: GenericFilterRequest = {
      numeroPagina: page,
      cantidad : this.rows,
      filtros: [
        {
          name:"Categoria",
          value:idCategoria,
        },
        {
          name: "SubCategoria",
          value:idSubCategoria
        }
      ],
    }

    this.cardProductService.listarProductos(req).subscribe({
      next:(res: GenericFilterResponse<CardProductResponse>)=>{
        this.products = res;
      }
    });
  }
  verCarga(data:CardProductResponse){
      let valid= true;
      var res = localStorage.getItem('product') ?? '';
      if(res == ''){
        this.list = [];
      }else{
        var limpio = JSON.parse(res) as CardProductResponse[];
        this.list = limpio;
      }
      for(var i of this.list){
        if(i.idProducto == data.idProducto){
          alert("Produto ya esta agregado");
          valid = false;
          break;
        }
      }
      if(valid){
        this.list.push(data);
        let json = JSON.stringify(this.list);
        localStorage.setItem('product',json);
      }

    }
    onPageChange(event: any) {
      this.first = event.first;
      this.rows = event.rows;
      if(this.fritro2 != 0){
        this.listarProductos('',this.fritro2.toString(),(this.first/this.rows)+1)
      }else
      if(this.fitro1 != 0){
        this.listarProductos(this.fitro1.toString(),'',(this.first/this.rows)+1);
      }
      else{
        this.listarProductos('','',(this.first/this.rows)+1);
      }
      
      
      
    }
}

