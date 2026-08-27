import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book-service';
import { Book } from '../../models/book';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.html',
  styleUrl: './book-list.css',
})
export class BookList implements OnInit {
  books: Book[] = [];

  constructor(
    private bookService: BookService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    console.log('booklist added');

    this.bookService.getBooks().subscribe((books) => {
      this.books = books;
    });
  }

  deleteBook(bookId: string): void {
    this.bookService.deleteBook(bookId).subscribe({
      next: (result) => {
            console.log('Book deleted:', result);
        this.bookService.getBooks().subscribe({
          next: (books) => {
            this.books = books;
          },
          error: (error) => {
            console.error('Error loading books:', error);
          },
        });
      },
      error: (error) => {
        console.error('Error deleting book:', error);
      },
    });

    this.router.navigate(['/books']);
  }

  updateBook(book: Book): void {
    this.router.navigate(['/books/update', book.id]);
  }
}
