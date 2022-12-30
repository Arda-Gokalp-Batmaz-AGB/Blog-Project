import { Component, OnInit } from '@angular/core';
import { responsePost } from '../models/responsePost';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '../services/blog.service';

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
  constructor(private _activatedRoute: ActivatedRoute,private blogService : BlogService) {
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
}
