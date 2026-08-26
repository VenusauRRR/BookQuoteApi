import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book-service';
import { Book } from '../../models/book';
@Component({
  selector: 'app-book-form',
  imports: [],
  templateUrl: './book-form.html',
  styleUrl: './book-form.css',
})
export class BookForm implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((books) => {
      this.books = books;
    });
  }
}
