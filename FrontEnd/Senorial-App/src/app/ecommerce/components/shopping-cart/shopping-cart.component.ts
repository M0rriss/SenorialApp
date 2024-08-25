import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CardProductComponent } from '../card-product/card-product.component';
import { CardProductResponse } from '@app/core/models/ecommerce/components/card-product/card-product-response';

@Component({
  selector: 'shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss'
})
export class ShoppingCartComponent implements OnInit {
  isShopOpen = false;
  @Output() cartUpdated = new EventEmitter<number>();
  //Campos

  products: CardProductResponse[] = []
  constructor(){
  }
  ngOnInit(): void {
    this.mostarCompras();
  }

  closeShop() {
    this.isShopOpen = false;
    const cartElement = document.querySelector('.shopping-cart-container') as HTMLElement;
      cartElement.style.display = 'none';
      const overlay = document.querySelector('.overlay') as HTMLElement;
  if (overlay) {
    overlay.style.display = 'none';  // O usa overlay.classList.add('hidden') si usas clases
  }
  }

  toggleShop() {
    this.isShopOpen = !this.isShopOpen;
  }

  cartItems = [
    {
      name: 'Hamburguesa',
      quantity: 1,
      price: 10.85,
      image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZpQ9NUgTcIJNgpVlQzZCUraE15UGGKrargA&s'
    }
  ];

  get subtotal() {
    return this.products.reduce((acc, item) => acc + item.precioVenta * item.quantity, 0).toFixed(2);
  }

  get total() {
    return this.subtotal;
  }
  updateCart() {
    const json = JSON.stringify(this.products);
    localStorage.setItem("product", json);
    const total = this.products.reduce((acc, item) => acc + item.precioVenta * item.quantity, 0);
    this.cartUpdated.emit(total);  // Emitir el nuevo total del carrito
  }
  incrementQuantity(item: CardProductResponse) {
    // item.quantity++;
    for(var i of this.products)
    {
      if(item.idProducto == i.idProducto){
          i.quantity++;
      }

    }

    var json =JSON.stringify(this.products);
    localStorage.setItem("product",json);
    this.updateCart();
  }

  decrementQuantity(item: any) {
    if (item.quantity > 1) {
      for(var i of this.products)
        {
          if(item.idProducto == i.idProducto){
              i.quantity--;
          }
        }
        var json =JSON.stringify(this.products);
        localStorage.setItem("product",json);
        this.updateCart();
    }
  }

  removeItem(item: CardProductResponse) {

    for(var i of this.products){
      if(i.idProducto == item.idProducto){
        let index = this.products.indexOf(item);

        if(index == this.products.length - 1 ){
          this.products = this.products.slice(0,index);
        break;

        }
        if(index == 0){
          this.products = this.products.slice(index+1,this.products.length);
        break;

        }
        var ar1 = this.products.slice(index+1,this.products.length);
        var ar2 = this.products.slice(0,index);
        this.products = ar2.concat(ar1);
        break;
      }
    }
    var json =JSON.stringify(this.products);
    localStorage.setItem("product",json);
    this.updateCart();
    // const index = this.cartItems.indexOf(item);
    // if (index > -1) {
    //   this.cartItems.splice(index, 1);
    // }
  }

  //FUNCIONALIDAD
  mostarCompras(){
    let json = localStorage.getItem('product') ?? '';
    if(json == ''){
      return;
    }
    let res = JSON.parse(json);
    this.products = res as CardProductResponse[];
    this.updateCart();
  }

}
