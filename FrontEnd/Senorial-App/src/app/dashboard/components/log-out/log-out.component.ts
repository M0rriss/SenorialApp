import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDashResponse } from '@app/core/models/dashboard/login/login-dash-response';
import { UsuarioResponse } from '@app/core/models/dashboard/mantenimiento/usuario/usuario-response';
import { LoginResponse } from '@app/core/models/login-request';

@Component({
  selector: 'log-out',
  templateUrl: './log-out.component.html',
  styleUrl: './log-out.component.scss'
})
export class LogOutComponent implements OnInit {
  //Var local
  usuarios: UsuarioResponse[] = [];
  userImageUrl: string = '';
  usuario: LoginDashResponse = {
    infoUser: {
      email: "",
      idPersona: 0,
      idRol: 0,
      nombre: "",
      rol: "",
    },
    message: "",
    refreshToken: "",
    success: true,
    token: "",
    tokenCreated: "",
    tokenExpires: "",
  }
  constructor(
    private route:Router
  ) { }
  ngOnInit(): void {
    this.cargarInfoUser();

  }

  isConfirmDialogOpen: boolean = false;
  closeConfirmDialog(): void {
    this.isConfirmDialogOpen = false;
  }
  deleteProduct(): void {
    // Lógica para eliminar producto
    this.isConfirmDialogOpen = false;
  }
  confirmDelete(): void {
    sessionStorage.removeItem('user');
    this.route.navigate(['']);
    // Lógica para confirmar eliminación de producto
    this.deleteProduct();
  }

  openConfirmDialog(): void {
    this.isConfirmDialogOpen = true;
  }

  cargarInfoUser(): void {
    const info: string = sessionStorage.getItem('user') || '';
    const img: string = sessionStorage.getItem('userImage') || '';
    if (info) {
      this.usuario = JSON.parse(info) as LoginDashResponse;
    }
    this.userImageUrl = img; // Leer la URL de la imagen
  }
}
