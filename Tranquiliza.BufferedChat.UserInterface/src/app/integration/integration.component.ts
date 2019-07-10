import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { User, Integration } from '../user';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-integration',
  templateUrl: './integration.component.html',
  styleUrls: ['./integration.component.scss']
})
export class IntegrationComponent implements OnInit {

  constructor(
    private userService: UserService,
    private sanitizer: DomSanitizer) {
  }

  user: User;
  integrations: Integration[];

  ngOnInit() {
    this.userService.GetUser('').subscribe(output => {
      this.user = output;
      this.integrations = this.user.integrations;
    });
  }

}
