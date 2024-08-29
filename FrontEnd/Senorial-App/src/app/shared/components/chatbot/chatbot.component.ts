import { Component } from '@angular/core';
import { ChatbotSlackService } from '../../services/chatbotslack.service';

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
constructor(
  private chatbotService : ChatbotSlackService
){

}

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
  async sendMessage() {
    if (this.newMessage.trim()) {
      this.addMessage(this.newMessage, 'user');
      const userMessage = this.newMessage;
      this.newMessage = '';
      this.isUserTyping = false;
      this.isBotTyping = true;

      let payload = {
        user_id: 'i1921197@continental.edu.pe',
        'in-0': userMessage
      };

      try {
        const botResponse = await this.getBotResponse(payload);
        this.simulateBotTyping(botResponse);
      } catch (err: any) {
        if (err.status === 402) {
          console.warn('Usando el fallback user_id debido al error 402');
          payload.user_id = 'yairnosde@gmail.com';
          try {
            const botResponse = await this.getBotResponse(payload);
            this.simulateBotTyping(botResponse);
          } catch (fallbackError) {
            this.handleBotError(fallbackError);
          }
        } else {
          this.handleBotError(err);
        }
      }
    }
  }

  private addMessage(text: string, sender: 'user' | 'bot') {
    this.messages.push({ text, sender });
  }

  private async getBotResponse(payload: any): Promise<string> {
    const data = await this.chatbotService.getChatBotAsync(payload);
    return data.outputs["out-0"].toString();
  }

  private simulateBotTyping(botResponse: string) {
    setTimeout(() => {
      this.addMessage(botResponse, 'bot');
      this.isBotTyping = false;
    }, 500); // Ajusta el tiempo de escritura para que sea más realista
  }

  private handleBotError(error: any) {
    console.error('Error al obtener respuesta del bot:', error);
    this.addMessage('Lo siento, ha ocurrido un error. Inténtalo de nuevo más tarde.', 'bot');
    this.isBotTyping = false;
  }
}
