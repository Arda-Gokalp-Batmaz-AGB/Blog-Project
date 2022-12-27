import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { constants } from '../Helper/constants';
import { responseUser } from '../models/responseUser';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
//AUTH GUARDI DÜZELT VE TOKENLERİ DÜZGÜN ŞEKİLDE YENİLEYEN BİR SİSTEM YAP
  constructor(private router : Router,private userService: UserService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const user = JSON.parse((localStorage.getItem(constants.USER_KEY) as string)) || JSON.parse((sessionStorage.getItem(constants.USER_KEY) as string));
    const currentUser = this.userService.currentUserValue;
    if (currentUser?.token) {
      // logged in so return true
      return true;
  }

  // not logged in so redirect to login page with the return url
  this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
  return false;
  }
}
