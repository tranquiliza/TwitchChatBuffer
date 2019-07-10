import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat.component';
import { ChatMessageDetailComponent } from './chat-message-detail/chat-message-detail.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { IntegrationComponent } from './integration/integration.component';

@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,
    ChatMessageDetailComponent,
    IntegrationComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
