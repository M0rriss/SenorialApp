import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { PrimeIcons } from 'primeng/api';
import { StepsModule } from 'primeng/steps';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputOtpModule } from 'primeng/inputotp';
import { PrimeNGConfig } from 'primeng/api';
import { AuthService } from '@app/ecommerce/services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginRecuperarRequest } from '@app/core/models/ecommerce/components/staff-personal/login-recuperar-request';
import { CustomResponse } from '@app/core/models/generic/custom-response';
import { LoginVerificarRequest } from '@app/core/models/ecommerce/components/staff-personal/login-verificar-request';
import { NotificationService } from '@app/shared/services/toast/notification.service';
@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrl: './forget-password.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class ForgetPasswordComponent implements OnInit{
  activeStep: number = 0;
  email: string = '';
  otpValue: string = '';
  newPassword: string = '';
  confirmPassword: string = '';

  loginPassForm:FormGroup;
  constructor(private primengConfig: PrimeNGConfig,
    private authService:AuthService,
    private fb:FormBuilder,
    private notificationService: NotificationService
  ) {
    this.loginPassForm = this.fb.group({
      nuevoPassword:["",Validators.required],
      confirmarContraseña:["",Validators.required],
    })
  }
  ngOnInit(): void {
    this.primengConfig.ripple = true;
  }
  //FUNCIONALIDAD
  recuparear(){
    let req : LoginRecuperarRequest ={
      email : this.email
    } ;

    this.authService.recuperar(req).subscribe({
      next: (res:CustomResponse) => {
        this.notificationService.showSecondary( 'Exito',res.message);
      }
    });
  }

  validar(){
    let req : LoginVerificarRequest = {
      email: this.email,
    codigoOtp : this.otpValue,
    nuevoPassword : this.newPassword,
    confirmarContraseña : this.confirmPassword,
  };
    this.authService.verificar(req).subscribe({
      next: (res:CustomResponse)=>{
        this.notificationService.showSecondary( 'Exito',res.message);
      }
    })
  }
  // Navega al siguiente paso
  nextStep() {
    if(this.activeStep == 0){
      this.recuparear()
    }
    if (this.activeStep < 2) {
      this.activeStep++;
    }
  }

  // Navega al paso anterior
  prevStep() {
    if (this.activeStep > 0) {
      this.activeStep--;
    }
  }

  // Método para guardar la nueva contraseña
  saveNewPassword() {
    if (this.newPassword === this.confirmPassword) {
      // Aquí añadirías la lógica para guardar la nueva contraseña
    } else {
    }
  }
 // Envía el email y avanza al siguiente paso
 sendEmail() {
  // if (this.email) {
  //   // Lógica para enviar el email (llamada a API, validación, etc.)
  //   console.log('Email enviado a:', this.email);
  //   this.nextStep();
  // } else {
  //   console.error('Por favor, ingrese un correo electrónico válido.');
  // }
}

// Valida el código OTP y avanza al siguiente paso
validateOTP() {
  if (this.otpValue === '1234') { // Simulación de validación OTP
    this.nextStep();
  } else {
  }
}
}
