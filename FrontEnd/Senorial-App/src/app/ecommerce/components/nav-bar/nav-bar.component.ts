import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDashResponse, LoginEcommerceResponse } from '@app/core/models/dashboard/login/login-dash-response';
import { CardProductResponse } from '@app/core/models/ecommerce/components/card-product/card-product-response';
import { LoginResponse } from '@app/core/models/login-request';


@Component({
  selector: 'ecommerce-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent implements OnInit {
  isMenuOpen = false;
  isMenuActive = false;
  isLoginOpen = false;
  isLoginActive = false;
  isShoppingCartOpen = false;
  isShoppingCartActive = false;
  isShopOpen = false;

  //CAMPOS
  user:string = "Ingresar";
  
  constructor(
    private route:Router
  ){
  }
  ngOnInit(): void {
    this.cargarInforUser();
  }

  //FUNCIONALIDAD
  cargarInforUser(){
    const data = localStorage.getItem('usuario') ?? '';
    if(data == ''){
      return;
    }
    const json = JSON.parse(data) as LoginEcommerceResponse;

    this.user = json.infoUsuario.nombre.substring(0,json.infoUsuario.nombre.indexOf(' '));
  }
  
  //UI
  toggleShop() {
    this.isShopOpen = !this.isShopOpen;
  }


  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
    this.isMenuActive = !this.isMenuActive;
    this.closeOtherPanels('menu');
  }

  toggleActive(buttonType: string) {
    if(this.user == "Ingresar"){
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
    else{
      if (buttonType === 'shopping-cart') {
        this.isShoppingCartOpen = !this.isShoppingCartOpen;
        this.isShoppingCartActive = !this.isShoppingCartActive;
        this.closeOtherPanels('shopping-cart');
      }
      else{
        this.route.navigate(['userAcount']);
      }
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
