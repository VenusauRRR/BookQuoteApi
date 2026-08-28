import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth-service';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginRequest } from '../../../models/login-request';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  request: LoginRequest = {
    username: '',
    password: '',
  };

  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  login(): void {
    this.authService.loginUser(this.request).subscribe({
      next: (result) => {
        console.log('User logged in, Token:', result);
        localStorage.setItem('token', result.token);
        this.router.navigate(['/books']);
      },
      error: (error) => {
        console.error('Error logging in user:', error);
      },
    });
  };
}
