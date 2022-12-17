import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AccountService} from "./Services/account.service";
import {User} from "./models/user";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Assay Database';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) {
  }

  ngOnInit() {
    this.getUsers()
    this.setCurrentUser();
  }

  getUsers() {
    this.http.get("https://localhost:5001/api/users").subscribe({
      next: res => this.users = res,
      error: err => console.log(err)
    })
  }

  // check local storage for user details, if found save to account service
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }

}
