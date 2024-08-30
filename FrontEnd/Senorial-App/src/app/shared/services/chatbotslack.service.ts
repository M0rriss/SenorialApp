import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ChatbotSlackService {

  private apiUrl = "https://api.stack-ai.com/inference/v0/run/39ddd56e-7132-415b-ae61-3be1ff47b2b3/66c742e118b6fba17f1a55fe";
  private apiKey = '1ac5d878-c658-46d7-a9cb-d302df6c08ae';

  private fallbackApiUrl = "https://api.stack-ai.com/inference/v0/run/7aec28f7-6ee5-4645-b5f4-c3bf56b90bad/66d089a9d76524f3a09d9b21";
  private fallbackApiKey = '30216b6d-a184-460c-8cca-8d1d50651e21';

  constructor(private http: HttpClient) {}

  async getChatBotAsync(req: any): Promise<any> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.apiKey}`);
    try {
      const response = await fetch(this.apiUrl, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${this.apiKey}`,
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(req)
      });
      const result = await response.json();
      return result;
    } catch (error) {
      console.error('Error en la consulta al bot:', error);
      throw error;
    }
  }
  private async callApi(fallbackApiUrl: string, fallbackApiKey: string, req: any): Promise<any> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${fallbackApiKey}`);
    try {
      const response = await fetch(fallbackApiUrl, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${fallbackApiKey}`,
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(req)
      });

      if (!response.ok) {
        const error = new Error(`HTTP error! status: ${response.status}`);
        (error as any).status = response.status;
        throw error;
      }

      const result = await response.json();
      return result;
    } catch (error) {
      throw error; // Lanzar error para ser manejado en el catch de `getChatBotAsync`
    }
  }

}
