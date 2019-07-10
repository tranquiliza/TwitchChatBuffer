import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }

  public BaseAddress(): string {
    return 'https://bufferedchatapi.azurewebsites.net/';
  }
}
