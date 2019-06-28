import { Component, OnInit } from '@angular/core';
import { MessagesService } from '../messages.service';
import { ChatMessage } from '../chatmessage';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  private regex = /[^\s]+(?!https?:\/\/static-cdn[^\s]+)|(https?:\/\/static-cdn[^\s]+)/g;
  private imageRegex = RegExp('(https?:\/\/static-cdn[^\s]+)');

  constructor(private messageService: MessagesService) { }

  public messages: ChatMessage[] = null;

  ngOnInit() {
    this.getMessages();
  }

  getMessages(): void {
    this.messageService.getMessages()
      .subscribe(output => {
        this.messages = output;
      });
  }
}
