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
import { createPost } from "../models/createPost";
import { createComment } from "../models/createComment";
import { interaction } from "../models/interaction";
import { userProfile } from "../models/userProfile";
import { follow } from "../models/follow";

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private readonly BASE_URL = "https://localhost:7038/api/Blog/";
  currentUser? : responseUser | null
  constructor(private http: HttpClient, private router : Router,private route: ActivatedRoute,private userService : UserService)
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
              x = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,
                x.parentID,x.authorID,x.authorName,x.likeCount,x.dislikeCount,x.postTitle)
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
    return this.http.get<responsePost>(this.BASE_URL + 'post/' + `${title}` ,).pipe(
      map((res : responsePost) => {
        let comments = res.comments.map(x => {
          x = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,x.parentID,
            x.authorID,x.authorName,x.likeCount,x.dislikeCount,x.postTitle)
          return x;
        });
        return new responsePost(res.id,res.title,res.authorID,comments,res.authorName);
      }),
      catchError(this.handleError),
    );
  }

  public getUserProfile(username : string): Observable<userProfile>
  {
    return this.http.get<userProfile>(this.BASE_URL + 'profile/' + `${username}` ,).pipe(
      map((res : userProfile) => {
        return new userProfile(res.id,res.userName,res.name,res.surname,res.about,res.followers,res.followeds,res.dateCreated);
      }),
      catchError(this.handleError),
    );
  }

  public getUserComments(username : string) : Observable<responseComment[]>
  {
    return this.http.get<responseComment[]>(this.BASE_URL + 'profile/' + `${username}` + '/activities' ,).pipe(
      map((res : responseComment[]) => {
        let comments = res.map(x => {
            x = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,x.parentID,
            x.authorID,x.authorName,x.likeCount,x.dislikeCount,x.postTitle)
          return x;
        });
        return comments;
      }),
      catchError(this.handleError),
    );
  }
  public createPost(authorID:string, title : string, text : string) : Observable<string>
  {
    const comment : createComment =
    {
      Text: text,
      PostID: -1,
      ParentID: -1,
      AuthorID: authorID
    }
    const body : createPost=
    {
      AuthorID:authorID,
      Title:title,
      FirstComment:comment
    }
    return this.http.post<string>(this.BASE_URL + "CreatePost",body,{ responseType: 'text' as 'json'}).pipe(
      catchError(this.handleError),
      shareReplay()
    );
  }
  public createComment(authorID:string, postID : number, parentID : number, text : string) : Observable<responseComment>
  {
    const comment : createComment =
    {
      Text: text,
      PostID: postID,
      ParentID: parentID,
      AuthorID: authorID
    }
    return this.http.post<responseComment>(this.BASE_URL + "CreateComment",comment,).pipe(
      catchError(this.handleError),
      shareReplay()
    );
  }
  public interactComment(commentID : number, interactionType : string, userID : string)
  {
    const interactionBody : interaction =
    {
      CommentID: commentID,
      InteractionType: interactionType,
      UserID: userID
    }
    return this.http.post<responseComment>(this.BASE_URL + "InteractComment",interactionBody).pipe(
      map((x : responseComment) => {
          let comment = new responseComment(x.id,x.text,x.dateCreated,x.dateModified,x.postID,x.parentID,
            x.authorID,x.authorName,x.likeCount,x.dislikeCount,x.postTitle)
        return comment;
      }),
      catchError(this.handleError),
      shareReplay()
    );
  }

  public followUnfollow(follower : string,followed : string)
  {
    const body : follow ={
      followerUserName: follower,
      followedUserName: followed
    }
    return this.http.post<userProfile>(this.BASE_URL + "Follow",body).pipe(
      catchError(this.handleError),
      shareReplay()
    );
  }
  public redirectAfterCreatePost()
  {
    //this.router.navigateByUrl('/postlist' as string);
    setTimeout(() => {
      this.router.navigate(['/postlist']);
  }, 3000)
  }


  private handleError(error : HttpErrorResponse)
  {
    return throwError(() => error);
  }
}
