import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { responseUser } from '../models/responseUser';
import { UserService } from '../services/user.service';
import { BlogService } from '../services/blog.service';
import { userProfile } from '../models/userProfile';
import { responseComment } from '../models/responseComment';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  visitorUser? : responseUser | null;
  username : string = "";
  user?: userProfile;
  showError : boolean = false;
  responseErrors? : string[];
  profileLoaded : boolean = false;
  userComments : responseComment[] = []
  constructor(private _activatedRoute: ActivatedRoute,private blogService : BlogService,private userService : UserService) {
    _activatedRoute.params.subscribe(params => {
      this.username = (params['username']);
      this.visitorUser = this.userService.currentUserValue;
      this.findUser();
      this.getUserComments();
    });
  }
  ngOnInit(): void {
    this.showProfile();
  }
  showProfile()
  {

  }
  editProfile()
  {

  }
  anotherProfile() : boolean{
    if(this.user?.userName == this.visitorUser?.userName)
    {
      return false;
    }
    return true;
  }

  checkIfFollows() : boolean{

    const followers = this.user?.followers
    if(followers?.includes(this.visitorUser!.userName))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  switchFollow() : void
  {
    this.blogService
      .followUnfollow(this.visitorUser!.userName,this.user!.userName)
      .subscribe({
        complete: () => {
          console.log('User followed sucessfully!');
          this.profileLoaded = true;
        }, // completeHandler
        error: (err) => {
          console.log('Error in followuser');
          this.showError = true;
          this.responseErrors = err;
          this.profileLoaded = true;
          console.log(err);
        },
        next: (res) => {
          console.log('Response: ');
          if(this.user?.followers.includes(this.visitorUser!.userName))
          {
            this.user.followers= this.user.followers.filter(x => x != this.visitorUser?.userName)
          }
          else{
            this.user?.followers.push(this.visitorUser!.userName);
          }
          console.log(res);
        },
      });
  }
  findUser()
  {
    this.blogService
      .getUserProfile(this.username)
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

  getUserComments() : void
  {
    this.blogService
    .getUserComments(this.username)
    .subscribe({
      complete: () => {
        console.log('Comments taken sucessfully!');
        this.profileLoaded = true;
      }, // completeHandler
      error: (err) => {
        console.log('Error in get comments');
        this.showError = true;
        this.responseErrors = err;
        this.profileLoaded = true;
        console.log(err);
      },
      next: (res) => {
        console.log('Response: ');
        this.userComments = res;
        console.log(res);
      },
    });
  }


}
