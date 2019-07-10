import { Injectable } from '@angular/core';
import { ChatMessage } from './chatmessage';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  private apiEndpoint = 'api/messages?pageSize=50&channelname=';

  constructor(
    private http: HttpClient,
    private apiService: ApiService) { }

  public getMessages(username: string): Observable<ChatMessage[]> {
    return this.http.get<ChatMessage[]>(this.apiService.BaseAddress() + this.apiEndpoint + username);
  }
}
