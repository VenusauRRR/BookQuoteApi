import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { CreateUser } from '../models/create-user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiUrl + '/users';
  constructor(private http: HttpClient) { }

  // getUsers(): Observable<User[]> {
  //   return this.http.get<User[]>(this.apiUrl);
  // }

  // getUserById(userId: string): Observable<User> {
  //   return this.http.get<User>(`${this.apiUrl}/get/${userId}`);
  // }

  registerUser(user: CreateUser): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/register`, user);
  }

}
