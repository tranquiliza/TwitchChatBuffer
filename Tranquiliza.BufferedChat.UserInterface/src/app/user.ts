export class User {
  id: string;
  twitchUsername: string;
  integrations: Integration[]
}

export class Integration {
  id: string;
  integrationUrl: string;
  isVisible: boolean;
}
