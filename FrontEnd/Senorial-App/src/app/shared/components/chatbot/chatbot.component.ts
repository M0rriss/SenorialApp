import { Component } from '@angular/core';

@Component({
  selector: 'chatbot',
  templateUrl: './chatbot.component.html',
  styleUrls: ['./chatbot.component.scss']
})
export class ChatbotComponent {
  isModalOpen = false;  // Controla si el modal está abierto o cerrado
  newMessage = '';      // Almacena el nuevo mensaje que el usuario escribe
  messages = [          // Arreglo de mensajes entre el usuario y el bot
    { sender: 'bot', text: 'Hola! ¿Cómo puedo ayudarte?' }
  ];

  // Método para alternar la visibilidad del modal
  toggleModal() {
    this.isModalOpen = !this.isModalOpen;
  }

  // Método para cerrar el modal cuando se hace clic fuera del contenido
  closeModal(event: Event) {
    const target = event.target as HTMLElement;
    if (target.classList.contains('modal')) {
      this.isModalOpen = false;
    }
  }

  // Método para enviar el mensaje
  sendMessage() {
    console.log('Mensaje enviado:', this.newMessage); // Para depurar el mensaje
    if (this.newMessage.trim()) {
      this.messages.push({ sender: 'user', text: this.newMessage });
      this.newMessage = ''; // Limpia el input después de enviar el mensaje

      setTimeout(() => {
        this.messages.push({ sender: 'bot', text: 'Gracias por tu mensaje. Estamos aquí para ayudarte.' });
      }, 1000);
    } else {
      console.error('El mensaje está vacío'); // Si el mensaje está vacío, muestra un error en la consola
    }
  }
}
