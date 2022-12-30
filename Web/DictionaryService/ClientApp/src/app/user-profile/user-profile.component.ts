import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { responseUser } from '../models/responseUser';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  username : string = "";
  user?: responseUser;
  showError : boolean = false;
  responseErrors? : string[];
  profileLoaded : boolean = false;
  constructor(private _activatedRoute: ActivatedRoute,private userService : UserService) {
    _activatedRoute.params.subscribe(params => {
      this.username = (params['username']);
      this.findUser();
    });
  }
  ngOnInit(): void {
    this.showProfile();
  }
  showProfile()
  {

  }
  findUser()
  {
    this.userService
      .getUser(this.username)
      .subscribe({
        complete: () => {
          console.log('User taken sucessfully!');
          this.profileLoaded = true;
        }, // completeHandler
        error: (err) => {
          console.log('Error in getuser');
          this.showError = true;
          this.responseErrors = err;
          this.profileLoaded = true;
          console.log(err);
        },
        next: (res) => {
          console.log('Response: ');
          this.user= res;
          console.log(res);
        },
      });
  }
}
