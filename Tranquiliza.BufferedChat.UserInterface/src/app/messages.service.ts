import { Injectable } from '@angular/core';
import { ChatMessage } from './chatmessage';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  private apiUrl = 'https://localhost:44374/api/messages?channelname=tranquiliza&pageSize=50';

  constructor(private http: HttpClient) { }

  public getMessages(): Observable<ChatMessage[]> {
    return this.http.get<ChatMessage[]>(this.apiUrl);
  }
}
