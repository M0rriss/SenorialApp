import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private messageService: MessageService) { }

  showSuccess(summary: string = 'Success', detail: string = 'Operation successful!'): void {
    this.messageService.add({ severity: 'success', summary, detail });
  }

  showInfo(summary: string = 'Info', detail: string = 'Information message.'): void {
    this.messageService.add({ severity: 'info', summary, detail });
  }

  showWarn(summary: string = 'Warning', detail: string = 'Warning message.'): void {
    this.messageService.add({ severity: 'warn', summary, detail });
  }

  showError(summary: string = 'Error', detail: string = 'An error occurred.'): void {
    this.messageService.add({ severity: 'error', summary, detail });
  }

  showContrast(summary: string = 'Contrast', detail: string = 'Contrast message content.'): void {
    this.messageService.add({ severity: 'contrast', summary, detail });
  }

  showSecondary(summary: string = 'Secondary', detail: string = 'Secondary message content.'): void {
    this.messageService.add({ severity: 'secondary', summary, detail });
  }
  displaySuccessToast(summary: string = 'Success', detail: string = 'Operation successful!', duration: number = 3000): void {
    this.messageService.add({ severity: 'success', summary, detail, life: duration });
  }

  displayInfoToast(summary: string = 'Info', detail: string = 'Information message.', duration: number = 3000): void {
    this.messageService.add({ severity: 'info', summary, detail, life: duration });
  }

  displayWarningToast(summary: string = 'Warning', detail: string = 'Warning message.', duration: number = 3000): void {
    this.messageService.add({ severity: 'warn', summary, detail, life: duration });
  }

  displayErrorToast(summary: string = 'Error', detail: string = 'An error occurred.', duration: number = 3000): void {
    this.messageService.add({ severity: 'error', summary, detail, life: duration });
  }

  displayContrastToast(summary: string = 'Contrast', detail: string = 'Contrast message content.', duration: number = 3000): void {
    this.messageService.add({ severity: 'contrast', summary, detail, life: duration });
  }

  displaySecondaryToast(summary: string = 'Secondary', detail: string = 'Secondary message content.', duration: number = 3000): void {
    this.messageService.add({ severity: 'secondary', summary, detail, life: duration });
  }
  clear(): void {
    this.messageService.clear();
  }
}
