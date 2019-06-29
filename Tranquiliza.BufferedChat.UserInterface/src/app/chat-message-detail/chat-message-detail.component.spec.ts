import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatMessageDetailComponent } from './chat-message-detail.component';

describe('ChatMessageDetailComponent', () => {
  let component: ChatMessageDetailComponent;
  let fixture: ComponentFixture<ChatMessageDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatMessageDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatMessageDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
