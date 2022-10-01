import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {

  state: {};
  constructor() {}
  /*
  *  @description wite item to app state
  */
  writeItem(key, value){
    localStorage.setItem(key, value ? JSON.stringify(value) : null);
  }

  /*
  *  @description read item to app state
  */
  readItem(key): any{
    const value = localStorage.getItem(key);
    let objetValue;
    try {
      objetValue = JSON.parse(value);
    } catch (error) {
      objetValue = null;
    }
    return objetValue;
  }

}
