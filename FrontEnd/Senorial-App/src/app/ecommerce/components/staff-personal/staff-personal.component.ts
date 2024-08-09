import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';
import { AuthService } from '@app/ecommerce/services/auth.service';

@Component({
  selector: 'staff-personal',
  templateUrl: './staff-personal.component.html',
  styleUrl: './staff-personal.component.scss'
})
export class StaffPersonalComponent {
  public showPassword: boolean = false;

  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
  //Formularo
  formLoginDash: FormGroup;

  constructor(private authService:AuthService,
    private fb:FormBuilder,
    private route:Router
  ){
    this.formLoginDash = this.fb.group({
      email: [],
      password:[],
    })
  }

  loginDash(){
    // Ya mejoran lo arlerts
    let req: LoginRequest = this.formLoginDash.value as LoginRequest;

    this.authService.login(req).subscribe({

      next: (res:LoginResponse)=>{
        // convertir un json en cadena de texto
        let data = JSON.stringify(res);
        // Almacenamiento en session store
        sessionStorage.setItem("user",data);
        // rutear a dashboard
        alert(res.message);
        this.route.navigate(['dashboard']);
      },

      error: (err)=>{
        //Manejo de errores
        var error = err.error.errors;
        var correct = err.error;
    
        if(error == undefined){
          alert(correct);
        }
        else{
          if(error.Email != null){
            alert(error.Email[0]);
          }
          if(error.Password != undefined){
            alert(error.Password[0])
          }
        }
      }
    });
  }
}
