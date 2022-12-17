import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../Services/account.service";
import {Observable, of} from "rxjs";
import {User} from "../../models/user";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}

  // async pipe - for unsubscribing
  // replaced by using the accountService directly in the template - needs to be public
  // currentUser$: Observable<User | null> = of(null) // of to set initial value

  constructor( public accountService: AccountService) { }

  ngOnInit(): void {
    // Set current user which can be used in any component implementing account service
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: res => {
        console.log(res);
      },
      error: err => console.log(err)
    })
  }

  logout() {
    this.accountService.logout();
  }

}
