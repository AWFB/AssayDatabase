import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AccountService} from "../../Services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {}

  constructor(private accountService: AccountService, private toast: ToastrService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => {
        this.toast.error(error.error);
        console.log(error)
      }
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
