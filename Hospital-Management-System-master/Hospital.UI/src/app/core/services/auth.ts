import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class Auth {

  // Base URL of your backend API
private apiUrl = 'https://localhost:5001/api/Auth';
  constructor(private http: HttpClient) { }

  login(data: LoginRequest): Observable<LoginResponse> {

    return this.http.post<LoginResponse>(
      `${this.apiUrl}/Login`,
      data
    );

  }

}