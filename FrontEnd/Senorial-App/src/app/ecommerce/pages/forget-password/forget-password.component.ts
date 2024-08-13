import { Component, OnInit } from '@angular/core';
import { PrimeIcons } from 'primeng/api';
import { StepsModule } from 'primeng/steps';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputOtpModule } from 'primeng/inputotp';
import { PrimeNGConfig } from 'primeng/api';
@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrl: './forget-password.component.scss'
})
export class ForgetPasswordComponent implements OnInit{
  activeStep: number = 0;
  email: string = '';
  otpValue: string = '';
  newPassword: string = '';
  confirmPassword: string = '';

  constructor(private primengConfig: PrimeNGConfig) {}
  ngOnInit(): void {
    this.primengConfig.ripple = true;
  }
  // Navega al siguiente paso
  nextStep() {
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
      console.log('Contraseña guardada con éxito');
    } else {
      console.error('Las contraseñas no coinciden');
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
    console.log('OTP validado correctamente');
    this.nextStep();
  } else {
    console.error('OTP incorrecto, por favor intente nuevamente.');
  }
}
}
