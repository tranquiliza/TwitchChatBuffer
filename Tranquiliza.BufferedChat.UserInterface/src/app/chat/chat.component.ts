import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MessagesService } from '../messages.service';
import { ChatMessage } from '../chatmessage';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { ApiService } from '../api.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, AfterViewInit {
  private hubConnection: HubConnection;
  constructor(
    private messageService: MessagesService,
    private userService: UserService,
    private apiService: ApiService) { }

  public messages: ChatMessage[] = null;

  ngOnInit() {
    this.userService.GetUser('').subscribe(output => {
      this.getMessages(output.twitchUsername);
    })
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl(this.apiService.BaseAddress() + 'messagehub').build();
    this.hubConnection.start();
    this.hubConnection.on('ReceiveMessage', (data: ChatMessage) => {
      this.messages.push(data);
    });
  }

  ngAfterViewInit() {
  }

  getMessages(username: string): void {
    this.messageService.getMessages(username)
      .subscribe(output => {
        this.messages = output.reverse();
      });
  }
}
