import { Component } from '@angular/core';

@Component({
  selector: 'iniciar-sesion-ecommerce',
  templateUrl: './iniciar-sesion.component.html',
  styleUrl: './iniciar-sesion.component.scss'
})
export class IniciarSesionComponent {
  isLogin: boolean = true;

  setActiveForm(value: string):void {
    this.isLogin = !this.isLogin;
  }
}
