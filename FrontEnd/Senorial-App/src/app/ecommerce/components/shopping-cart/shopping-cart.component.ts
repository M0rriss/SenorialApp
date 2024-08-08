import { Component } from '@angular/core';

@Component({
  selector: 'shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss'
})
export class ShoppingCartComponent {
  isShopOpen = false;

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
    return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0).toFixed(2);
  }

  get total() {
    return this.subtotal;
  }

  incrementQuantity(item: any) {
    item.quantity++;
  }

  decrementQuantity(item: any) {
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
