import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDisplayDto } from '../models/user';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5229/api/User';

  constructor(
    private http: HttpClient,
    private authService: AuthService
  ) { }

  private getHeaders(): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  getUsers(): Observable<UserDisplayDto[]> {
    return this.http.get<UserDisplayDto[]>(this.apiUrl);
  }

  getAdminMessage(): Observable<string> {
    return this.http.get<string>(`${this.apiUrl}/Admins`, {
      headers: this.getHeaders()
    });
  }
}
