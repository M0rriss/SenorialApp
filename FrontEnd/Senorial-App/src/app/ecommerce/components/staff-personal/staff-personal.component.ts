import { Component } from '@angular/core';

@Component({
  selector: 'staff-personal',
  templateUrl: './staff-personal.component.html',
  styleUrl: './staff-personal.component.scss'
})
export class StaffPersonalComponent {
  public showPassword: boolean = false;

  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
}
