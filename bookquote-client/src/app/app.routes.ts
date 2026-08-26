import { Routes } from '@angular/router';
import { BookList } from './books/book-list/book-list';

export const routes: Routes = [
  {
    path: 'books',
    component: BookList,
  },
];
