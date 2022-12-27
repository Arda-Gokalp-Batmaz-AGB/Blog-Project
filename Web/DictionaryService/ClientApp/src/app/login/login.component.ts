import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { constants } from '../Helper/constants';
import { UserService } from '../services/user.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
  ) {}
  loginForm: FormGroup | any;
  userNameIsValid?: boolean;
  passwordIsValid?: boolean;
  authenticationInvalidResponse?: boolean;
  //returnUrl? : string;
  @ViewChild('submitButton', { static: false }) public submitButton:
    | ElementRef<HTMLButtonElement>
    | any;

  ngOnInit(): void {
    //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';
    this.loginForm = this.formBuilder.group({
      username: this.formBuilder.control(
        '',
        Validators.compose([Validators.required])
      ),
      password: this.formBuilder.control(
        '',
        Validators.compose([Validators.required])
      ),
      rememberme: this.formBuilder.control(false, Validators.compose([])),
    });
    this.createReactiveValidations();
  }

  createReactiveValidations(): void {
    this.loginForm
      .get('username')
      .statusChanges.pipe()
      .subscribe((res: any) => {
        if (res == 'VALID') {
          this.userNameIsValid = true;
        }
      });
    this.loginForm
      .get('password')
      .statusChanges.pipe()
      .subscribe((res: any) => {
        if (res == 'VALID') {
          this.passwordIsValid = true;
        }
      });
  }
  login(user: any) {
    if (this.loginForm.status != 'VALID') {
      if (this.loginForm.get('username').status == 'INVALID') {
        this.userNameIsValid = false;
      }
      if (this.loginForm.get('password').status == 'INVALID') {
        this.passwordIsValid = false;
      }
      console.log('form is not valid');
      return;
    }

    console.log(user);
    this.submitButton.nativeElement.disabled = true;
    this.userService
      .login(user.username, user.password, user.rememberme)
      .subscribe({
        complete: () => {
          console.log('Login sucessfully!');
          this.submitButton.nativeElement.disabled = false;
          this.authenticationInvalidResponse = false;
          //this.router.navigate(['home']);
          this.userService.redirectAfterLogin();
          // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';
          // this.router.navigateByUrl(this.returnUrl as string);
        }, // completeHandler
        error: (err) => {
          console.log('Error in Authentication');
          console.log(err);
          this.authenticationInvalidResponse = true;
          this.submitButton.nativeElement.disabled = false;
        },
        next: (res) => {
          console.log('Response: ');
          var response = JSON.parse(JSON.stringify(res));
          console.log('Token = ' + response['token']);
          console.log(response);
          //localStorage.setItem(constants.USER_KEY, JSON.stringify(res));
        },
      });
  }
}
