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
    const btnGroup = document.getElementsByName('btnGroup');

    document.documentElement.setAttribute(
      'data-bs-theme',
      this.isDarkMode ? 'dark' : 'light'
    );

    if (this.isDarkMode) {
      nav?.classList.remove('bg-warning');
    } else {
      nav?.classList.add('bg-warning');
    }


    // if (this.isDarkMode) {
    //   nav?.classList.add('navbar-dark');
    //   nav?.classList.add('bg-secondary');
    //   nav?.classList.remove('navbar-light');
    //   nav?.classList.remove('bg-warning');
    //   btnGroup.forEach((btn) => { btn.classList.add('btn-secondary'); btn.classList.remove('btn-warning') });
    // } else {
    //   nav?.classList.add('navbar-light');
    //   nav?.classList.add('bg-warning');
    //   nav?.classList.remove('navbar-dark');
    //   nav?.classList.remove('bg-secondary');
    //   btnGroup.forEach((btn) => { btn.classList.remove('btn-secondary'); btn.classList.add('btn-warning') });
    // }
    
  }

}
