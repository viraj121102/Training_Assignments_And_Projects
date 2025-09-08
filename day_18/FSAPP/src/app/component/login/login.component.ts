import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  img = 'https://angular.io/assets/images/logos/angular/angular.png';
  username: string = '';
  password: string = '';
  col: number = 2;

}
