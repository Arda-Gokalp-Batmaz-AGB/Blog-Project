import { Injectable } from '@angular/core';
import { constants } from '../Helper/constants';
const TOKEN_KEY = 'authToken';
const REFRESHTOKEN_KEY = 'refreshToken';
@Injectable({
  providedIn: 'root',
})
export class TokenStorageService {
  constructor() {}

  public saveAuthToken(token: Object): void {
    localStorage.removeItem(TOKEN_KEY);
    //stingify the token
    const tokenString = JSON.stringify(token);
    localStorage.setItem(TOKEN_KEY, tokenString);
    const user = this.getUser();
    if (user.id) {
      this.saveUser({ ...user, accessToken: token });
    }
  }
  public getAuthToken(): any {
    const token = localStorage.getItem(TOKEN_KEY);
    if (token) {
      return JSON.parse(token);
    } else {
      return null;
    }
  }
  public saveRefreshToken(token: Object): void {
    localStorage.removeItem(REFRESHTOKEN_KEY);
    const tokenString = JSON.stringify(token);
    localStorage.setItem(REFRESHTOKEN_KEY, tokenString);
  }
  public getRefreshToken(): any {
    const refreshToken = localStorage.getItem(REFRESHTOKEN_KEY);

    if (refreshToken) {
      return JSON.parse(refreshToken);
    } else {
      return null;
    }
  }
  public saveUser(user: any): void {
    localStorage.removeItem(constants.USER_KEY);
    const userString = JSON.stringify(user);
    localStorage.setItem(constants.USER_KEY, JSON.stringify(userString));
  }
  public getUser(): any {
    let user = JSON.parse(localStorage.getItem(constants.USER_KEY) as string );
    if(user == null)
    {
      user= JSON.parse(sessionStorage.getItem(constants.USER_KEY) as string);
    }
    if (user) {
      return user;
    }
    return {};
  }

  public clearTokens(): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(REFRESHTOKEN_KEY);
    localStorage.removeItem(constants.USER_KEY);
    sessionStorage.removeItem(constants.USER_KEY);
  }
}
