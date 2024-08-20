import { Component } from '@angular/core';
import { NotificationService } from '@app/shared/services/toast/notification.service';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
})
export class ExampleComponent {
  constructor(private notificationService: NotificationService) { }

  showToast() {
    this.notificationService.showSuccess('Operación Exitosa', 'Los datos se han guardado correctamente.');
  }

  showLightErrorToast() {
    this.notificationService.showError('Error', 'Ocurrió un problema.'); // Modo claro
  }
}
/* Estilos base para el toast */
// .ui-toast {
//   .ui-toast-message {
//     display: flex;
//     align-items: center;
//     justify-content: space-between;
//     border-radius: 5px;
//     padding: 10px 20px;
//     font-family: 'Poppins', sans-serif;
//     font-size: 16px;
//     color: #ffffff;
//   }

//   .ui-toast-message-success {
//     background-color: #28a745; /* Verde oscuro */
//     border-left: 5px solid #218838;
//   }

//   .ui-toast-message-info {
//     background-color: #17a2b8; /* Azul oscuro */
//     border-left: 5px solid #117a8b;
//   }

//   .ui-toast-message-warn {
//     background-color: #ffc107; /* Amarillo oscuro */
//     border-left: 5px solid #d39e00;
//     color: #212529;
//   }

//   .ui-toast-message-error {
//     background-color: #dc3545; /* Rojo oscuro */
//     border-left: 5px solid #c82333;
//   }

//   .ui-toast-message-custom-dark {
//     background-color: #343a40; /* Gris oscuro */
//     border-left: 5px solid #23272b;
//   }

//   /* Estilos para la versión clara */
//   .ui-toast-message-light-success {
//     background-color: #d4edda; /* Verde claro */
//     border-left: 5px solid #28a745;
//     color: #155724;
//   }

//   .ui-toast-message-light-info {
//     background-color: #d1ecf1; /* Azul claro */
//     border-left: 5px solid #17a2b8;
//     color: #0c5460;
//   }

//   .ui-toast-message-light-warn {
//     background-color: #fff3cd; /* Amarillo claro */
//     border-left: 5px solid #ffc107;
//     color: #856404;
//   }

//   .ui-toast-message-light-error {
//     background-color: #f8d7da; /* Rojo claro */
//     border-left: 5px solid #dc3545;
//     color: #721c24;
//   }

//   .ui-toast-message-light-custom {
//     background-color: #e2e3e5; /* Gris claro */
//     border-left: 5px solid #343a40;
//     color: #383d41;
//   }
// }
