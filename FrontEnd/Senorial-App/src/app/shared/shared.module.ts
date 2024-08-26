import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MessageService } from 'primeng/api';
import { ChatbotComponent } from './components/chatbot/chatbot.component';


@NgModule({
  declarations: [

    ChatbotComponent
  ],
  imports: [
    CommonModule,
    DialogModule,
    BrowserModule,
    FormsModule,
    ToastModule
  ],
  exports:[
    DialogModule,
    ChatbotComponent
  ],
  providers: [MessageService],
})
export class SharedModule { }
