import { Component, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginDashResponse } from '@app/core/models/dashboard/login/login-dash-response';
import { LoginRequest, LoginResponse } from '@app/core/models/login-request';
import { StaffPersonalService } from '@app/ecommerce/service/components/staff-personal/staff-personal.service';
import { AuthService } from '@app/ecommerce/services/auth.service';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'staff-personal',
  templateUrl: './staff-personal.component.html',
  styleUrl: './staff-personal.component.scss',
  encapsulation: ViewEncapsulation.None

})
export class StaffPersonalComponent {
  public showPassword: boolean = false;

  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
  //Formularo
  formLoginDash: FormGroup;

  constructor(private staffService:StaffPersonalService,
    private fb:FormBuilder,
    private route:Router,
    private notificationService: NotificationService
  ){
    this.formLoginDash = this.fb.group({
      email: [],
      password:[],
    })
  }

  loginDash(){
    // Ya mejoran lo arlerts
    let req: LoginRequest = this.formLoginDash.value as LoginRequest;

    this.staffService.loginDashboard(req).subscribe({

      next: (res:LoginDashResponse)=>{
        // convertir un json en cadena de texto
        let data = JSON.stringify(res);
        // Almacenamiento en session store
        sessionStorage.setItem("user",data);
        // rutear a dashboard
        this.notificationService.showSuccess(res.message,'Se ha iniciado sesión correctamente');
        //this.notificationService.displaySuccessToast('Login exitoso', 'Se ha iniciado sesión correctamente', 5000);
        setTimeout(() => {
          this.route.navigate(['dashboard']);
      }, 1500);
        //this.route.navigate(['dashboard']);
      },
      error: (err) => {
        var error = err.error.errors;
        var correct = err.error;

        if (error == undefined) {
          this.notificationService.showError('Error', correct);
        } else {
          if (error.Email != null) {
            this.notificationService.showWarn('Error en el email', error.Email[0]);
          }
          if (error.Password != undefined) {
            this.notificationService.showWarn('Error en la contraseña', error.Password[0]);
          }
        }
      }
    });
  }
}
