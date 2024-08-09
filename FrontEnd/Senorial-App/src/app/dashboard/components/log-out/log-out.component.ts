import { Component, OnInit } from '@angular/core';
import { LoginResponse } from '@app/core/models/login-request';

@Component({
  selector: 'log-out',
  templateUrl: './log-out.component.html',
  styleUrl: './log-out.component.scss'
})
export class LogOutComponent implements OnInit {
  //Var local
  constructor(){}
  ngOnInit(): void {
    this.cargarInfoUser();
  }

  email:string = ''
  isConfirmDialogOpen: boolean = false;
  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }
  deleteProduct(): void {
    // Lógica para eliminar producto
    this.isConfirmDialogOpen = false;
  }
  confirmDelete(): void {
    // Lógica para confirmar eliminación de producto
    this.deleteProduct();
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  cargarInfoUser(): void{
    var info:string = sessionStorage.getItem('user') || '';
    let user = JSON.parse(info) as LoginResponse;
    this.email = user.usuario.email;
  }
}
