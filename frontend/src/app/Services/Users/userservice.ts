import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StudentInterface } from '../../Interfaces/student-interface';

@Injectable({
  providedIn: 'root',
})
export class Userservice {
  private ApiUrl = 'http://localhost:5110/users';

  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  GetUserLogged() {
    return this.http.get<any>(this.ApiUrl);
  }
}
