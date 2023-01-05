import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';
import { responseUser } from '../models/responseUser';
import { responseComment } from '../models/responseComment';
@Component({
  selector: 'app-createcomment',
  templateUrl: './createcomment.component.html',
  styleUrls: ['./createcomment.component.css']
})
export class CreatecommentComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private blogService : BlogService,private userService : UserService) { }

  currentUser? : responseUser | null
  createPostForm: FormGroup | any;
  maxCharsText = 400;
  maxCharsTitle = 40;
  @Input() postID = -2;
  @Input() parentID = -2;
  @Output() commentEventEmitter = new EventEmitter<responseComment>();

  @ViewChild('submitButton', { static: false }) public submitButton:
  | ElementRef<HTMLButtonElement>
  | any;
  ngOnInit(): void {
    this.createPostForm = this.formBuilder.group({
      text: [""],
    });
  }
  create(postContent: any)
  {
      this.submitButton.nativeElement.disabled = true;
      this.currentUser = this.userService.currentUserValue
      const text = postContent.text.toString();
      this.blogService
      .createComment(this.currentUser!.id,this.postID,this.parentID, text)
      .subscribe({
        complete: () => {
          console.log('comment Created Sucessfully!');
          this.submitButton.nativeElement.disabled = false;
        }, // completeHandler
        error: (err : any) => {
          console.log('Error in comment creation');
          console.log(err);
          this.submitButton.nativeElement.disabled = false;
        },
        next: (res : responseComment) => {
          this.commentEventEmitter.emit(res)
        },
      });
  }

}
