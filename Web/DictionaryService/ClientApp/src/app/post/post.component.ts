import { Component, Input, OnInit } from '@angular/core';
import { responsePost } from '../models/responsePost';
import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';
import { responseUser } from '../models/responseUser';
import { responseComment } from '../models/responseComment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor(private userService : UserService,private blogService : BlogService) { }

  currentUser? : responseUser | null
  @Input() post! : responsePost
  interactionCount = 0;
  ngOnInit(): void {
  }

  updatePost(type : string) : void
  {
    this.currentUser = this.userService.currentUserValue
    if(!this.currentUser!.id)
    {
      this.userService.returnLoginPage();
      return;
    }
    this.blogService.interactComment(this.post.comments[0].id,type,this.currentUser!.id).subscribe({
      next: (x : responseComment) => {

      this.post.comments[0].likeCount = x.likeCount;
      this.post.comments[0].dislikeCount =  x.dislikeCount;
    },
    error: (err) => {
      console.log('Error in interaction');
      console.log(err);
    },
  });
  }

  interactionPost(interecactionType : string) : void
  {
    this.updatePost(interecactionType);
  }
}
