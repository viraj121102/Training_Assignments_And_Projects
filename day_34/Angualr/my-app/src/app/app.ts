import { Component, signal } from '@angular/core';
import { Store, StoreModule } from '@ngrx/store';
import { Observable } from 'rxjs';
import { increment, decrement, reset } from './counter/counter.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('my-app');
  counter$: Observable<number>;

  constructor(private store: Store<{ counter: number }>) {
    this.counter$ = this.store.select('counter');
  }

  increment() {
    this.store.dispatch(increment());
  }

  decrement() {
    this.store.dispatch(decrement());
  }

  reset() {
    this.store.dispatch(reset());
  }
}
