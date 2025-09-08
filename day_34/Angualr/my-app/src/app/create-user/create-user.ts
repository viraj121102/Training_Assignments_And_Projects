import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { IUser } from '../../Interface/users.interface';
import { addUser } from '../users/users.actions';

@Component({
  selector: 'app-create-user',
  standalone: false,
  templateUrl: './create-user.html',
  styleUrl: './create-user.css'
})
export class CreateUser {
  name = 'nitesh';
  email = 'nitesh@example.com';

  constructor(private store: Store) {}

  addUser() {
    const newUser: IUser = {
      id: Date.now(),
      name: this.name,
      email: this.email
    };
    this.store.dispatch(addUser({ user: newUser }));
    // this.name = '';
    // this.email = '';
  }
}
