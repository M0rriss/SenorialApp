import { Component } from '@angular/core';


@Component({
  selector: 'ecommerce-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
  isMenuOpen = false;
  isMenuActive = false;
  isLoginOpen = false;
  isLoginActive = false;
  isShoppingCartOpen = false;
  isShoppingCartActive = false;
  isShopOpen = false;

  toggleShop() {
    this.isShopOpen = !this.isShopOpen;
    const cartContainer = document.querySelector('.shopping-cart-container') as HTMLElement;
    const cart = document.querySelector('.cart-container') as HTMLElement;

    if (this.isShopOpen) {
      cartContainer.classList.add('visible');
      cartContainer.classList.remove('hidden');
      setTimeout(() => {
        cart.classList.add('open');
      }, 10); // Pequeña demora para que la animación se vea suave
    } else {
      cart.classList.remove('open');
      setTimeout(() => {
        cartContainer.classList.remove('visible');
        cartContainer.classList.add('hidden');
      }, 300); // Debe coincidir con la duración de la transición
    }
 }
  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
    this.isMenuActive = !this.isMenuActive;
    this.closeOtherPanels('menu');
  }

  toggleActive(buttonType: string) {
    if (buttonType === 'login') {
      this.isLoginOpen = !this.isLoginOpen;
      this.isLoginActive = !this.isLoginActive;
      this.closeOtherPanels('login');
    } else if (buttonType === 'shopping-cart') {
      this.isShoppingCartOpen = !this.isShoppingCartOpen;
      this.isShoppingCartActive = !this.isShoppingCartActive;
      this.closeOtherPanels('shopping-cart');
    }
  }

  closeOtherPanels(activePanel: string) {
    if (activePanel !== 'menu') {
      this.isMenuOpen = false;
      this.isMenuActive = false;
    }
    if (activePanel !== 'login') {
      this.isLoginOpen = false;
      this.isLoginActive = false;
    }
    if (activePanel !== 'shopping-cart') {
      this.isShoppingCartOpen = false;
      this.isShoppingCartActive = false;
    }
  }

}
