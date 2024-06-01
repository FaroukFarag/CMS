import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { StorageService } from '../shared/storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiURL = 'https://localhost:7096/api/Users';

  constructor(private http: HttpClient, private storageService: StorageService) { }

  register(user: any): Observable<string> {
    return this.http.post(`${this.apiURL}/register`, user, { responseType: 'text' })
      .pipe(
        tap(token => this.saveToken(token))
      );
  }

  login(credentials: any): Observable<string> {
    return this.http.post(`${this.apiURL}/login`, credentials, { responseType: 'text' })
      .pipe(
        tap(token => this.saveToken(token))
      );
  }

  saveToken(token: string): void {
    this.storageService.setItem('jwtToken', token);

    const payload = JSON.parse(atob(token.split('.')[1]));

    this.storageService.setItem('tokenExpiry', payload.exp);
  }

  getToken(): string | null {
    return this.storageService.getItem('jwtToken');
  }

  getTokenExpiry(): number | null {
    const expiry = this.storageService.getItem('tokenExpiry');
    return expiry ? Number(expiry) : null;
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    const expiry = this.getTokenExpiry();
    if (!token || !expiry) {
      return false;
    }
    return Date.now() < expiry * 1000;
  }

  logout(): void {
    this.storageService.removeItem('jwtToken');
    this.storageService.removeItem('tokenExpiry');
  }
}
