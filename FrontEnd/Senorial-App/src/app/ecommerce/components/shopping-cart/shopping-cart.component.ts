import { Component } from '@angular/core';

@Component({
  selector: 'shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss'
})
export class ShoppingCartComponent {
  cartItems = [
    // Ejemplo de items, puedes reemplazar con los items reales de tu aplicación
    {
      name: 'Hamburguesa',
      quantity: 100,
      price: 10.85,
      image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZpQ9NUgTcIJNgpVlQzZCUraE15UGGKrargA&s'
    },
    // {
    //   name: 'Hamburguesa',
    //   quantity: 100,
    //   price: 10.85,
    //   image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZpQ9NUgTcIJNgpVlQzZCUraE15UGGKrargA&s'
    // },
   
    
    
   
  ];

  get subtotal() {
    return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0).toFixed(2);
  }

  get total() {
    // Asume que no hay impuestos ni descuentos por ahora
    return this.subtotal;
  }
  incrementQuantity(item?: number){
    
  }
  decrementQuantity(item?: number){
    
  }
}
