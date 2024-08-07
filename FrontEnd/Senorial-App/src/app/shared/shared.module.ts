import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { ExampleComponent } from './components/example/example.component';
import { ToastModule } from 'primeng/toast';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MessageService } from 'primeng/api';


@NgModule({
  declarations: [
    ExampleComponent
  ],
  imports: [
    CommonModule,
    DialogModule,
    BrowserModule,
    FormsModule,
    ToastModule
  ],
  exports:[
    DialogModule
  ],
  providers: [MessageService],
})
export class SharedModule { }
