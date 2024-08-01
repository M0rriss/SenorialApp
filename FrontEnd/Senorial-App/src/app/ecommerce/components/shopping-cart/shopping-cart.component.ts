import { Component } from '@angular/core';

@Component({
  selector: 'shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss'
})
export class ShoppingCartComponent {
  isShopOpen = false;

  toggleShop() {
    this.isShopOpen = !this.isShopOpen;
    const cartElement = document.querySelector('.shopping-cart-container') as HTMLElement;
    if (this.isShopOpen) {
      cartElement.classList.add('open');
    } else {
      cartElement.classList.remove('open');
    }
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
    return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0).toFixed(2);
  }

  get total() {
    return this.subtotal;
  }

  incrementQuantity(item:any) {
    item.quantity++;
  }

  decrementQuantity(item:any) {
    if (item.quantity > 0) {
      item.quantity--;
    }
  }

  removeItem(item: any) {
    const index = this.cartItems.indexOf(item);
    if (index > -1) {
      this.cartItems.splice(index, 1);
    }
  }

}
