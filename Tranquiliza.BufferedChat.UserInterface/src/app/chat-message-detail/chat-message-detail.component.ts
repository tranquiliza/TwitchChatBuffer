import { Component, OnInit, Input } from '@angular/core';
import { ChatMessage } from '../chatmessage';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-chat-message-detail',
  templateUrl: './chat-message-detail.component.html',
  styleUrls: ['./chat-message-detail.component.scss']
})

export class ChatMessageDetailComponent implements OnInit {
  @Input() message: ChatMessage;
  constructor() { }

  readableDate = '';

  ngOnInit() {
    this.readableDate = formatDate(this.message.receivedAt, 'MMMM dd hh:mm:ss', 'en-GB');
  }
}
