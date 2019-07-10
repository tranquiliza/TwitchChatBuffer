import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiEndpoint = 'api/users/';

  public user: User;

  constructor(
    private http: HttpClient,
    private apiService: ApiService) { }

  public GetUser(userId: string): Observable<User> {
    return this.http.get<User>(this.apiService.BaseAddress() + this.apiEndpoint + userId);
  }
}
