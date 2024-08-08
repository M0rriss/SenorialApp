import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private messageService: MessageService) { }

  showSuccess(summary: string, detail: string, isLight: boolean = false): void {
    const severity = isLight ? 'light-success' : 'success';
    this.messageService.add({ severity, summary, detail });
  }

  showInfo(summary: string, detail: string, isLight: boolean = false): void {
    const severity = isLight ? 'light-info' : 'info';
    this.messageService.add({ severity, summary, detail });
  }

  showWarn(summary: string, detail: string, isLight: boolean = false): void {
    const severity = isLight ? 'light-warn' : 'warn';
    this.messageService.add({ severity, summary, detail });
  }

  showError(summary: string, detail: string, isLight: boolean = false): void {
    const severity = isLight ? 'light-error' : 'error';
    this.messageService.add({ severity, summary, detail });
  }

  showCustom(summary: string, detail: string, isDark: boolean = true): void {
    const severity = isDark ? 'custom-dark' : 'light-custom';
    this.messageService.add({ severity, summary, detail });
  }

  clear(): void {
    this.messageService.clear();
  }
}
