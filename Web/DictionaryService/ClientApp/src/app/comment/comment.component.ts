import { Component, Input, OnInit } from '@angular/core';
import { responseComment } from '../models/responseComment';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  constructor() { }

  @Input() comment! : responseComment
  ngOnInit(): void {
  }

}
