import { Component, Input, OnInit } from '@angular/core';
import { responseComment } from '../models/responseComment';
import { responseUser } from '../models/responseUser';
import { UserService } from '../services/user.service';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  constructor(private userService : UserService,private blogService : BlogService) { }

  @Input() comment! : responseComment
  currentUser? : responseUser | null
  @Input() minimizedComment : boolean = false;
  ngOnInit(): void {
  }
  updateComment(type : string) : void
  {
    this.currentUser = this.userService.currentUserValue
    if(!this.currentUser!.id)
    {
      this.userService.returnLoginPage();
      return;
    }
    this.blogService.interactComment(this.comment.id,type,this.currentUser!.id).subscribe({
      next: (x : responseComment) => {

      this.comment.likeCount = x.likeCount;
      this.comment.dislikeCount =  x.dislikeCount;
    },
    error: (err : any) => {
      console.log('Error in interaction');
      console.log(err);
    },
  });
  }

  interactionComment(interecactionType : string) : void
  {
    this.updateComment(interecactionType);
  }
}
