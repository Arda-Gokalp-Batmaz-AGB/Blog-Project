import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { map, Observable,catchError, throwError, shareReplay, BehaviorSubject } from "rxjs";
import {loginUser} from 'src/app/models/loginUser'
import {registerUser} from 'src/app/models/registerUser'
import { from } from "rxjs";
import { responseUser } from "../models/responseUser";
import { ActivatedRoute, Router } from "@angular/router";
import { constants } from "../Helper/constants";
import { TokenStorageService } from "../token-storage/token-storage.service";
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly BASE_URL = "https://localhost:5001/api/User/";

  private currentUserSubject: BehaviorSubject<responseUser | null>;
  public currentUser: Observable<responseUser | null>;
  constructor(private http: HttpClient, private router : Router,private route: ActivatedRoute,private tokenStorageService: TokenStorageService)
  {
    this.currentUserSubject = new BehaviorSubject<responseUser | null>(this.tokenStorageService.getUser());
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public login(userNameOrEmail:string, password : string, rememberme : boolean) : Observable<responseUser>
  {
    const body : loginUser=
    {
      EmailorUserName:userNameOrEmail,
      Password:password,
      RememberMe:rememberme,
    }
    return this.http.post<responseUser>(this.BASE_URL + "Login",body).pipe(
      catchError(this.handleError),
      shareReplay(),
      map((value : responseUser) => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        var user = new responseUser(value.id,value.userName,value.email,value.dateCreated,value.token);
        if(body.RememberMe == true)
        {
          localStorage.setItem(constants.USER_KEY, JSON.stringify(user));
        }
        else
        {
          sessionStorage.setItem(constants.USER_KEY, JSON.stringify(user));
        }
        this.currentUserSubject.next(user);
        return user;
    })
    );
  }

  public register(userName:string, email : string, password : string) : Observable<string>
  {
    const body : registerUser=
    {
      UserName:userName,
      Email:email,
      Password:password
    }
    return this.http.post<string>(this.BASE_URL + "Register",body,{ responseType: 'text' as 'json'}).pipe(
      catchError(this.handleError),
      shareReplay()
    );
  }

  public getAllUsers() : Observable<Array<responseUser>>
  {
    //let userInfo = JSON.parse((localStorage.getItem(constants.USER_KEY)) as string);
   // var header = new HttpHeaders().set("Authorization", "Bearer " + userInfo.token);//{headers : header}
    return this.http.get<responseUser[]>(this.BASE_URL + "Users",).pipe(
      map((res : responseUser[]) => {
        let userList = new Array<responseUser>();
        if(res)
        {
          res.map((value) => {
            userList.push(new responseUser(value.id,value.userName,value.email,value.dateCreated,value.token));
          })
        }
        return userList;
      }),
      catchError(this.handleError),

    )
  }
  public getUser(username : string): Observable<responseUser>
  {
    return this.http.get<responseUser>(this.BASE_URL + `${username}` ,).pipe(
      map((res : responseUser) => {
        return new responseUser(res.id,res.userName,res.email,res.dateCreated,res.token);
      }),
      catchError(this.handleError),
    );
  }

  public logout()
  {
    this.tokenStorageService.clearTokens();
    this.currentUserSubject.next(null);
    this.returnLoginPage();
  }

  public returnLoginPage()
  {
    this.router.navigate(['/login'])
  }
  public redirectAfterLogin()
  {
    this.router.navigateByUrl(this.route.snapshot.queryParams['returnUrl'] || '/home' as string);
  }
  public get currentUserValue(): responseUser | null {
    return this.currentUserSubject.value;
}

  private handleError(error : HttpErrorResponse)
  {
    return throwError(() => error);
  }
}
