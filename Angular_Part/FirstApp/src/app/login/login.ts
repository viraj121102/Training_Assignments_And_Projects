import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  
  SayHello()
  {
    alert('Hello!!,Hope you are well');
  }
}
