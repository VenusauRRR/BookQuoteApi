import { Component, OnInit } from '@angular/core';
import { CreateUser } from '../../../models/create-user';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth-service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  imports: [FormsModule],
  templateUrl: './register-user.html',
  styleUrl: './register-user.css',
})
export class RegisterUser {

  user: CreateUser = {
    username: '',
    email: '',
    password: '',
  };
  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  registerUser(): void {
    this.authService.registerUser(this.user).subscribe({
      next: (result) => {
        console.log('User created:', result);
        this.router.navigate(['/auth/login']);
      },
      error: (error) => {
        console.error('Error registering user:', error);
      },
    });
  };
};
