import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../Services/account.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

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

  constructor( public accountService: AccountService,
               private router: Router,
               private toast: ToastrService) { }

  ngOnInit(): void {
    // Set current user which can be used in any component implementing account service
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/assays'),
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }

}
