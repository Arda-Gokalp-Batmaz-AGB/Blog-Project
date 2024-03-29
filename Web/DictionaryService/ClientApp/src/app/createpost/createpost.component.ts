import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';
import { responseUser } from '../models/responseUser';
import AWN from "awesome-notifications"
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private blogService : BlogService,private userService : UserService,private toaster:ToastrService) { }

  currentUser? : responseUser | null
  createPostForm: FormGroup | any;
  maxCharsText = 500;
  maxCharsTitle = 40;
  operationApproved = false;
  @ViewChild('submitButton', { static: false }) public submitButton:
  | ElementRef<HTMLButtonElement>
  | any;
  ngOnInit(): void {
    this.createPostForm = this.formBuilder.group({
      text: [""],
      title: [""]
    });
  }
  create(postContent: any)
  {
      this.submitButton.nativeElement.disabled = true;
      this.currentUser = this.userService.currentUserValue

      this.blogService
      .createPost(this.currentUser!.id, postContent.title, postContent.text)
      .subscribe({
        complete: () => {
          console.log('Post Created Sucessfully!');
          this.submitButton.nativeElement.disabled = false;
          this.blogService.redirectAfterCreatePost(postContent.title);
        }, // completeHandler
        error: (err) => {
          console.log('Error in post creation');
          console.log(err);
          this.submitButton.nativeElement.disabled = false;
        },
        next: (res) => {
          this.toaster.success('You have sucessfully added your Post!', 'Post Added');

        },
      });
  }

}
