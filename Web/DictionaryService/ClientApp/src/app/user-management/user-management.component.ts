import { Component, OnInit } from '@angular/core';
import { responseUser } from '../models/responseUser';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
})
export class UserManagementComponent implements OnInit {
  constructor(private userService: UserService) {}
  users?: responseUser[];
  ngOnInit(): void {
    this.GetAllUsers();
  }
  GetAllUsers() {
    this.userService.getAllUsers().subscribe({
      next: (res) => {
        this.users = res;
        console.log(res);
      },
      error: (err) => {
        console.log('Error while getall');
        this.userService.returnLoginPage();
      },
      complete: () => {
        console.log('All users listed sucessfully');
      },
    });
  }
}
