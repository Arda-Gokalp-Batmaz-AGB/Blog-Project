import { Component } from '@angular/core';
import { responseUser } from './models/responseUser';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  currentUser? : responseUser | null
  constructor(private userService : UserService){}

  onLogout()
  {
    this.userService.logout();
  }

  isUserLogin() : boolean
  {
    this.currentUser = this.userService.currentUserValue;
    if(this.currentUser?.token)
    {
      return true;
    }
    return false;
  }
}
