import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../../Interface/users.interface';
import { select, Store } from '@ngrx/store';
import { UsersState } from '../users/users.reducer';

@Component({
  selector: 'app-view-user',
  standalone: false,
  templateUrl: './view-user.html',
  styleUrl: './view-user.css'
})
export class ViewUser {
  users$: Observable<IUser[]>;
  
  constructor(private store: Store<{ users: UsersState }>) {
    this.users$ = this.store.pipe(select(state => state.users.users));
    console.log("Current Users State:", this.users$);
  }

}
