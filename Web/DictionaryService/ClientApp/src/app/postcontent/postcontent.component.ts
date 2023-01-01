import { Component, OnInit } from '@angular/core';
import { responsePost } from '../models/responsePost';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';
import { responseUser } from '../models/responseUser';
import { responseComment } from '../models/responseComment';

@Component({
  selector: 'app-postcontent',
  templateUrl: './postcontent.component.html',
  styleUrls: ['./postcontent.component.css']
})
export class PostcontentComponent implements OnInit {
  postTitle : string = "";
  post?: responsePost;
  showError : boolean = false;
  responseErrors? : string[];
  postLoaded : boolean = false;
  currentUser? : responseUser | null
  interactionCount = 0;
  constructor(private _activatedRoute: ActivatedRoute,
    private blogService : BlogService,private userService : UserService) {
    _activatedRoute.params.subscribe(params => {
      this.postTitle = (params['title']);
      this.findPost();
    });
  }
  ngOnInit(): void {
  }

  findPost()
  {
    this.blogService
    .getPost(this.postTitle)
    .subscribe({
      complete: () => {
        console.log('Post taken sucessfully!');
        this.postLoaded = true;
        this.getInteractionCount();
      }, // completeHandler
      error: (err) => {
        console.log('Error in getpost');
        this.showError = true;
        this.responseErrors = err;
        this.postLoaded = true;
        console.log(err);
      },
      next: (res) => {
        console.log('Response: ');
        this.post= res;
        console.log(res);
      },
    });
  }
  updatePost(type : string) : void
  {
    this.currentUser = this.userService.currentUserValue
    if(!this.currentUser!.id)
    {
      this.userService.returnLoginPage();
      return;
    }
    this.blogService.interactComment(this.post!.comments[0].id,type,this.currentUser!.id).subscribe({
      next: (x : responseComment) => {

      this.post!.comments[0].likeCount = x.likeCount;
      this.post!.comments[0].dislikeCount =  x.dislikeCount;
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

  getInteractionCount()
  {
    this.interactionCount = this.post!.comments.length - 1;
    this.post!.comments.forEach((comment) =>{
      const likeDislikeCount = comment.likeCount + comment.dislikeCount
      this.interactionCount += likeDislikeCount
    })
  }
}
