import {Injectable} from '@angular/core';
import {CanActivate} from '@angular/router';
import {map, Observable} from 'rxjs';
import {AccountService} from "../Services/account.service";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountService: AccountService, private toast: ToastrService) {
  }

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (user) return true;
        else {
          this.toast.error("You do not have permission to go here!");
          return false;
        }
      })
    )
  }

}
