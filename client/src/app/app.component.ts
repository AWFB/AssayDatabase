import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Assay Database';
  users: any;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.http.get("https://localhost:5001/api/users").subscribe({
      next: res => this.users = res,
      error: err => console.log(err)
    })
  }


}
