import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import { CardProductResponse } from '@app/core/models/ecommerce/components/card-product/card-product-response';

@Component({
  selector: 'card-product',
  templateUrl: './card-product.component.html',
  styleUrl: './card-product.component.scss'
})
export class CardProductComponent {
  @Input({alias:"Producto"}) data:CardProductResponse = {
    idProducto: 0,
    detalleProducto: "",
    nombreProducto: "",
    precioVenta: 0,
    rutaImagen: "",
    quantity:1
  };

  @Output() produto = new EventEmitter<CardProductResponse>();

  enviarProducto(info:CardProductResponse){
    info.quantity = 1;
    this.produto.emit(info);
  }
}
