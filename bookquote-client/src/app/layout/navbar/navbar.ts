import { Component, EventEmitter, Output } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth-service';


@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})

export class Navbar {

  @Output() themeChanged = new EventEmitter<boolean>();
  public isDarkMode: boolean = false;
  constructor(
    public authService: AuthService,
    private router: Router
  ) { }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  toggleTheme(): void {

    this.isDarkMode = !this.isDarkMode;

    this.themeChanged.emit(this.isDarkMode);

    const nav = document.querySelector('nav');
    const footer = document.querySelector('footer');
    const btnGroup = document.getElementsByName('btnGroup');

    document.documentElement.setAttribute(
      'data-bs-theme',
      this.isDarkMode ? 'dark' : 'light'
    );

    if (this.isDarkMode) {
      nav?.classList.remove('bg-warning');
      footer?.classList.remove('bg-warning');
    } else {
      nav?.classList.add('bg-warning');
      footer?.classList.add('bg-warning');
    }
  }

}
