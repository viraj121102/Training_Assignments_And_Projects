import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from "./login/login";
import { Signal } from "./signal/signal";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Login, Signal],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('app');

  display=true;
  toggleDiv=true;

  HideDiv()
  {
    this.display=false;
  }
  ShowDiv()
  {
    this.display=true;
  }
  toggle()
  {
  this.display=!this.display;
    
  }

  toggleTwo()
  {
    this.toggleDiv=!this.toggleDiv;
  }
}
