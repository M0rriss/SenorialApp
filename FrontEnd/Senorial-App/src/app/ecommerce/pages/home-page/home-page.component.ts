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
  //
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
    this.listarProductos(data.toString());
  }
  recibirSubCategoria(data:number){
    this.listarProductos("",data.toString());
  }

  listarProductos(idCategoria:string = "",idSubCategoria:string=""):void{
    let req: GenericFilterRequest = {
      numeroPagina: 1,
      cantidad : 10,
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

}

