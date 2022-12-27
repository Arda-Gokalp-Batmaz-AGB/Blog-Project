import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HttpXhrBackend, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { JwtInterceptor } from './interceptors/JwtInterceptor';
import { ErrorCatchingInterceptor } from './interceptors/ErrorCatchingInterceptor';
import { GlobalErrorHandler } from './handlers/GlobalErrorHandler';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    UserManagementComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    {provide: ErrorHandler, useClass: GlobalErrorHandler},{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },{ provide: HTTP_INTERCEPTORS, useClass: ErrorCatchingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
