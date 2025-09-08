import { createReducer, on } from "@ngrx/store";
import { IUser } from "../../Interface/users.interface";
import { addUser, loadUsers, loadUsersFailure, loadUsersSuccess } from "./users.actions";

export interface UsersState {
  users: IUser[];
}
export const initialState: UsersState = { users: [] };

console.log("Initial Users State:", initialState);
export const usersReducer = createReducer(
    initialState,
    on(loadUsersSuccess, (state, { users }) => ({ ...state, users: [...state.users, users] })),
    on(loadUsersFailure, (state, { error }) => {
        console.error("Error loading users:", error);
        return state;
    }),
    on(loadUsers, (state) => {
        console.log("Loading users...");
        return state;
    }),
    on(addUser, (state, { user }) => ({ ...state, users: [...state.users, user] }))
);
