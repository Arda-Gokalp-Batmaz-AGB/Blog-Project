import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { map, Observable,catchError, throwError, shareReplay, BehaviorSubject } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
import { constants } from "../Helper/constants";
import { TokenStorageService } from "../token-storage/token-storage.service";
import { responseUser } from "../models/responseUser";
import { UserService } from "./user.service";
import { responsePost } from "../models/responsePost";
import { responseComment } from "../models/responseComment";

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private readonly BASE_URL = "https://localhost:7038/api/Blog/";
  currentUser? : responseUser | null
  constructor(private http: HttpClient, private router : Router,private userService : UserService)
  {
    this.currentUser = this.userService.currentUserValue;
  }

  public getAllPosts() : Observable<Array<responsePost>>
  {
    return this.http.get<responsePost[]>(this.BASE_URL + "Posts",).pipe(
      map((res : responsePost[]) => {
        let postList = new Array<responsePost>();
        if(res)
        {
          res.map((value) => {
            let comments = value.comments.map(x => {
              x = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,x.parentID,x.authorID,x.authorName)
              return x;
            });
            postList.push(new responsePost(value.id,value.title,value.authorID,comments,value.authorName));
          })
        }
        return postList;
      }),
      catchError(this.handleError),

    )
  }
  public getPost(title : string): Observable<responsePost>
  {
    return this.http.get<responsePost>(this.BASE_URL + `${title}` ,).pipe(
      map((res : responsePost) => {
        let comments = res.comments.map(x => {
          x = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,x.parentID,x.authorID,x.authorName)
          return x;
        });
        return new responsePost(res.id,res.title,res.authorID,comments,res.authorName);
      }),
      catchError(this.handleError),
    );
  }


  private handleError(error : HttpErrorResponse)
  {
    return throwError(() => error);
  }
}
