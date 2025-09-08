// import { createAction } from "@ngrx/store";
// import { IUser } from "../../Interface/users.interface";

// export const loadUsers = createAction("[Users] Load Users");
// export const loadUsersSuccess = createAction("[Users] Load Users Success", (users: IUser) => ({ users }));
// export const loadUsersFailure = createAction("[Users] Load Users Failure", (error: any) => ({ error }));
// export const addUser = createAction("[Users] Add User", (user: IUser) => ({ user }));


import { createAction, props } from "@ngrx/store";
import { IUser } from "../../Interface/users.interface";

export const loadUsers = createAction("[Users] Load Users");
export const loadUsersSuccess = createAction(
  "[Users] Load Users Success",
  props<{ users: IUser }>()
);
export const loadUsersFailure = createAction(
  "[Users] Load Users Failure",
  props<{ error: any }>()
);

export const addUser = createAction(
  "[Users] Add User",
  props<{ user: IUser }>()
);
