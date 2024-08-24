import { Component } from '@angular/core';

@Component({
  selector: 'chatbot',
  templateUrl: './chatbot.component.html',
  styleUrls: ['./chatbot.component.scss']
})
export class ChatbotComponent {
  messages = [
    { text: 'Hola! ¿Cómo puedo ayudarte?', sender: 'bot' },
    // Otros mensajes...
  ];
  newMessage: string = '';
  isModalOpen: boolean = false;
  isBotTyping: boolean = false;
  isUserTyping: boolean = false;
  userTypingTimeout: any;

  toggleModal(event: Event) {
    this.isModalOpen = !this.isModalOpen;
    event.stopPropagation();
  }

  stopClose(event: Event) {
    event.stopPropagation();
  }

  userTyping() {
    this.isUserTyping = true;
    clearTimeout(this.userTypingTimeout);

    this.userTypingTimeout = setTimeout(() => {
      this.isUserTyping = false;
    }, 1000);
  }

  sendMessage() {
    if (this.newMessage.trim()) {
      this.messages.push({ text: this.newMessage, sender: 'user' });
      this.newMessage = '';
      this.isUserTyping = false;
      this.isBotTyping = true;

      // Simular que el bot está escribiendo
      setTimeout(() => {
        this.messages.push({ text: 'Gracias por tu mensaje. Estamos aquí para ayudarte.', sender: 'bot' });
        this.isBotTyping = false;
      }, 2000); // El bot responde después de 2 segundos
    }
  }
}
