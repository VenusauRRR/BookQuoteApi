import { Routes } from '@angular/router';
import { BookList } from './features/books/book-list/book-list';
import { BookForm } from './features/books/book-form/book-form';
import { Login } from './features/auth/login/login';
import { RegisterUser } from './features/auth/register-user/register-user';
import { QuoteList } from './features/quotes/quote-list/quote-list';
import { QuoteForm } from './features/quotes/quote-form/quote-form';

export const routes: Routes = [
  {
    path: 'books',
    component: BookList,
  },
  {
    path: 'books/add',
    component: BookForm,
  },
  {
    path: 'books/update/:bookId',
    component: BookForm,
  },
  {
    path: 'auth/login',
    component: Login,
  },
  {
    path: 'auth/register',
    component: RegisterUser,
  },
  {
    path: 'quotes',
    component: QuoteList,
  },
  {
    path: 'quotes/add',
    component: QuoteForm,
  },
  {
    path: 'quotes/update/:quoteId',
    component: QuoteForm,
  }
];
