import { Component, OnInit } from '@angular/core';
import { BlogService } from '../services/blog.service';
import { responsePost } from '../models/responsePost';

@Component({
  selector: 'app-postlist',
  templateUrl: './postlist.component.html',
  styleUrls: ['./postlist.component.css']
})
export class PostlistComponent implements OnInit {

  constructor(private blogService: BlogService) { }

  posts?: responsePost[];
  ngOnInit(): void {
    this.GetAllPosts();
  }
  GetAllPosts() {
    this.blogService.getAllPosts().subscribe({
      next: (res) => {
        this.posts = res.reverse();
        console.log(res);
      },
      error: (err) => {
        console.log('Error while getall');
      },
      complete: () => {
        console.log('All posts listed sucessfully');
      },
    });
  }

}
