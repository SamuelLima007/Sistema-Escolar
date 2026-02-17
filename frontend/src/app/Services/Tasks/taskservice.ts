import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class Taskservice {
  private ApiUrl = 'http://localhost:5110/users';

  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  GetNextTasks() {
    return this.http.get<any>(this.ApiUrl);
  }
}
