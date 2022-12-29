import { Component, Input, OnInit } from '@angular/core';
import { responsePost } from '../models/responsePost';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  constructor() { }

  @Input() post! : responsePost
  ngOnInit(): void {
  }

}
