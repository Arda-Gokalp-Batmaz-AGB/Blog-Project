import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { map, Observable,catchError, throwError, shareReplay, BehaviorSubject } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
import { constants } from "../Helper/constants";
import { TokenStorageService } from "../token-storage/token-storage.service";
import { responseUser } from "../models/responseUser";
import { UserService } from "./user.service";

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private readonly BASE_URL = "https://localhost:5001/api/User/";
  currentUser? : responseUser | null
  constructor(private userService : UserService)
  {
    this.currentUser = this.userService.currentUserValue;
  }
}
