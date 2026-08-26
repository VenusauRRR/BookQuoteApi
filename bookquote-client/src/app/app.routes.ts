import { Routes } from '@angular/router';
import { BookList } from './books/book-list/book-list';
import { BookForm } from './books/book-form/book-form';

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
];
