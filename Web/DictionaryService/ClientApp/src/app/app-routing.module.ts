import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth-guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { PostlistComponent } from './postlist/postlist.component';
import { PostcontentComponent } from './postcontent/postcontent.component';
import { CreatepostComponent } from './createpost/createpost.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'usermanagement', component: UserManagementComponent , canActivate : [AuthGuard]},
  { path: 'newpost', component: CreatepostComponent , canActivate : [AuthGuard]},
  { path: 'profile/:username', component: UserProfileComponent},
  { path: 'post/:title', component: PostcontentComponent},
  { path: 'postlist', component: PostlistComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
