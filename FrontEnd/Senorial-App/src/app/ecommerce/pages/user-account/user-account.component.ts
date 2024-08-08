import { Component } from '@angular/core';

@Component({
  selector: 'user-account-ecommerce',
  templateUrl: './user-account.component.html',
  styleUrl: './user-account.component.scss'
})
export class UserAccountComponent {

  showPasswordFields = false;

  togglePasswordFields() {
    this.showPasswordFields = !this.showPasswordFields;
  }
}
