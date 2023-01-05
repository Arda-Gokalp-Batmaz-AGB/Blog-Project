import { Component, ContentChild, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators,FormBuilder, ValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { disableDebugTools } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { UserService } from '../services/user.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router : Router,private userService : UserService,private formBuilder : FormBuilder,private toaster:ToastrService) { }
  registerForm : FormGroup | any;
  emailIsValid?: boolean;
  userNameIsValid?: boolean;
  passwordIsValid?: boolean;
  registrationInvalidResponse?: boolean;
  responseErros? : string[];
  @ViewChild('submitButton', { static: false }) public submitButton : ElementRef<HTMLButtonElement> | any;
  ngAfterViewInit() {
   }
  ngOnInit(): void {
    this.registerForm = this.formBuilder.group
    ({
      username : this.formBuilder.control('',Validators.compose([
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(20),
        Validators.pattern('^[A-Za-z0-9_-]*$'),
       ])),
      email : this.formBuilder.control('',Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$'),
       ])),
      password : this.formBuilder.control('', Validators.compose([
        Validators.required,
        Validators.minLength(6),
        RegisterComponent.patternValidator(/\d/, { hasNumber: true }),
        RegisterComponent.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
        RegisterComponent.patternValidator(/[a-z]/, { hasSmallCase: true }),
        RegisterComponent.patternValidator(/[*.@!#%&()^~{}]+/, {hasSpecialCharacter : true}),
      ])),
      passwordConfirm : this.formBuilder.control('', Validators.compose([
        //this.passwordMatchValidator(this.formBuilder)
      ]))
    },   {
      // our validator for the form group
      validator: this.passwordMatchValidator
    });
    this.createReactiveValidations();
  }

  register(user : any)
  {
   // console.log(user)
    this.registerForm.markAllAsTouched();
    if(this.registerForm.status != "VALID")
    {
      this.userNameIsValid = false
      this.passwordIsValid = false;
      this.emailIsValid = false;
      console.log("form is not valid");
      return;
    }

    console.log(user);
    this.submitButton.nativeElement.disabled = true;
    this.userService.register(user.username,user.email,user.password).subscribe({
      complete: () =>
      {
        console.log("Register sucessfully!");
        this.submitButton.nativeElement.disabled = false;
        this.registrationInvalidResponse = false;
        this.responseErros = [];
        this.toaster.success('You have sucessfully registered', 'Register');
        this.router.navigate(["login"]);
      }, // completeHandler
      error: (err) =>
      {
        console.log("Error in Registration ");
        this.toaster.error('A problem occured in registration', 'Register');
        console.log(err);
        this.responseErros = err;
        this.submitButton.nativeElement.disabled = false;
        this.registrationInvalidResponse = true;
      },
      next:(res) => {
      console.log("Response:");
      console.log(res);},
    })
  }
  createReactiveValidations() : void
  {
    this.registerForm.get('username').statusChanges.pipe(
      debounceTime(1000),
      distinctUntilChanged()).subscribe((res : any) => {
        if(res == "VALID")
        {
          this.userNameIsValid = true;
        }
        else
        {
          this.userNameIsValid = false;
        }
      });
      this.registerForm.get('email').statusChanges.pipe(
        debounceTime(1000),
        distinctUntilChanged()).subscribe((res : any) => {
          if(res == "VALID")
          {
            this.emailIsValid = true;
          }
          else
          {
            this.emailIsValid = false;
          }

        });
    this.registerForm.get('password').statusChanges.pipe(
      debounceTime(1000),
      distinctUntilChanged()).subscribe((res : any) => {
        if(res == "VALID")
        {
          this.passwordIsValid = true;
        }
        else
        {
          this.passwordIsValid = false;
        }
        console.log(this.registerForm.controls['passwordConfirm'].hasError('misMatchedPasswords'))
      });
  }
  protected  passwordMatchValidator(control: AbstractControl) {
    const password: string = control.get('password')?.value; // get password from our password form control
    const confirmPassword: string = control.get('passwordConfirm')?.value; // get password from our confirmPassword form control
    // compare is the password math
    if (password !== confirmPassword) {
      // if they don't match, set an error in our confirmPassword form control
      control.get('passwordConfirm')?.setErrors({ misMatchedPasswords: true });
    }
  }
protected static patternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {
  return (control: AbstractControl): any => {
    if (!control.value) {
      return null;
    }
    const valid = regex.test(control.value);
    return valid ? null : error
  };
}
}
