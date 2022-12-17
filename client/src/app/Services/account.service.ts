import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map} from "rxjs";
import {User} from "../models/user";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/'

  //behaviour subject allows observable to have an initial value
  private currentUserSource = new BehaviorSubject<User | null>(null); // | = union type, can be of type user or null
  currentUser$ = this.currentUserSource.asObservable() // store current user as observable

  constructor(private http: HttpClient) {
  }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      // Persist login by storing user in local storage for browser
      // Map applies the function to what is returned before being passed to subscriber
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        localStorage.setItem('user', JSON.stringify(user))
        this.currentUserSource.next(user);
      })
    )
  }

  // Set current user from component
  setCurrentUser(user: User) {
    this.currentUserSource.next(user)
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
