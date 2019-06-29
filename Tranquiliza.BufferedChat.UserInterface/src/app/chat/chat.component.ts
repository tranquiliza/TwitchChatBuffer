import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MessagesService } from '../messages.service';
import { ChatMessage } from '../chatmessage';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, AfterViewInit {
  private hubConnection: HubConnection;
  private regex = /[^\s]+(?!https?:\/\/static-cdn[^\s]+)|(https?:\/\/static-cdn[^\s]+)/g;
  private imageRegex = RegExp('(https?:\/\/static-cdn[^\s]+)');

  constructor(private messageService: MessagesService) { }

  public messages: ChatMessage[] = null;

  ngOnInit() {
    this.getMessages();
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl('https://localhost:44374/messagehub').build();
    this.hubConnection.start();
    this.hubConnection.on('ReceiveMessage', (data: ChatMessage) => {
      this.messages.push(data);
    });
  }

  ngAfterViewInit() {
  }

  getMessages(): void {
    this.messageService.getMessages()
      .subscribe(output => {
        this.messages = output.reverse();
      });
  }

  addMessage(): void {
    const newMessage = new ChatMessage();
    newMessage.channel = 'TEST';
    newMessage.userColorHex = '#456874';
    newMessage.displayName = 'ILOVETESTING';
    newMessage.message = 'Angular can do certain things to itself';
    newMessage.receivedAt = new Date();

    this.messages.push(newMessage);
  }

}
