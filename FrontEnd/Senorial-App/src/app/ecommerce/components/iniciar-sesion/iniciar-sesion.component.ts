import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginDashResponse, LoginEcommerceResponse } from '@app/core/models/dashboard/login/login-dash-response';
import { LoginRegisterRequest } from '@app/core/models/ecommerce/components/staff-personal/login-register-request';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';
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
    email: ["",Validators.required],
    password: ["",Validators.required]
  });
  loginRegistroForm: FormGroup;
  constructor(
    private auth:AuthService,
    private fb:FormBuilder,
    private route:Router
  ){
    this.loginRegistroForm = this.fb.group({
      nombres: [null,Validators.required],
      apellidos: [null,Validators.required],
      tipoDocumento: ['Tipo de Documento',Validators.required],
      numeroDocumento: [null,Validators.required],
      celular: [null,Validators.required],
      emailRegistro: ["",Validators.required],
      passwordRegistro: ["",Validators.required],
    });
  }
  //FUNCIONALIDAD
  logIn(){
    const data:LoginRequest = {...this.loginForm.value} as LoginRequest;
    this.auth.login(data).subscribe({
      next: (res:LoginEcommerceResponse) =>{
        this.loginError = false;
        localStorage.setItem("usuario",JSON.stringify(res));
        alert(res.message);
        this.route.navigate(['userAcount']);
      },
      error: (_)=>{ this.loginError = true;}
    })
  }
  registro(){
    let req = this.loginRegistroForm.value as LoginRegisterRequest;
    req.email = this.loginRegistroForm.getRawValue().emailRegistro;
    req.password = this.loginRegistroForm.getRawValue().passwordRegistro;
    this.auth.Registro(req).subscribe({
      next: (res:LoginResponse)=>{
        alert("Se registro correctamente");
        this.loginRegistroForm.reset();
        this.setActiveForm('login');
      }
    })
  }
  
  // recuperar(){
  //   this.auth.recuperar().subscribe({
  //     next: ()=>{

  //     }
  //   });
  // }
  //UI
  setActiveForm(value: string):void {
    this.isLogin = !this.isLogin;
  }
  togglePasswordVisibility(inputId: string, iconId: string): void {
    const passwordInput = document.getElementById(inputId) as HTMLInputElement;
    const icon = document.getElementById(iconId) as HTMLElement;

    if (passwordInput.type === 'password') {
      passwordInput.type = 'text';
      icon.classList.remove('fa-eye');
      icon.classList.add('fa-eye-slash');
    } else {
      passwordInput.type = 'password';
      icon.classList.remove('fa-eye-slash');
      icon.classList.add('fa-eye');
    }
  }
}
