import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
  imports: [CommonModule, FormsModule]
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  success: boolean = false;

  login() {
    console.log('Email:', this.email);
    console.log('Password:', this.password);

    if (this.email === 'het@example.com' && this.password === '123456') {
      this.success = true;
    } else {
      alert('Invalid credentials');
      this.success = false;
    }
  }
}
