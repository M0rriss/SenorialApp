import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginRequest } from '@app/core/models/login-request';
import { AuthService } from '@app/ecommerce/services/auth.service';

@Component({
  selector: 'iniciar-sesion-ecommerce',
  templateUrl: './iniciar-sesion.component.html',
  styleUrl: './iniciar-sesion.component.scss'
})
export class IniciarSesionComponent {
  isLogin: boolean = true;
  loginError:boolean = false;
  loginForm = this.fb.group({
    email: ["",Validators.required,Validators.email],
    password: ["",Validators.required]
  })
  constructor(
    private auth:AuthService,
    private fb:FormBuilder
  ){

  }
  logIn(){
    console.log(this.loginForm)
    const data:LoginRequest = {...this.loginForm.value} as LoginRequest;
    this.auth.login(data).subscribe({
      next: (res) =>{
        this.loginError = false;
        localStorage.setItem("usuario",JSON.stringify(res));
        console.log(res);
      },
      error: (_)=>{ this.loginError = true;}
    })
  }
  setActiveForm(value: string):void {
    this.isLogin = !this.isLogin;
  }
}
