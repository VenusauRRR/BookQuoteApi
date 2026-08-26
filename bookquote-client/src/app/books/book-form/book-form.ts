import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book-service';
import { Book } from '../../models/book';
import { FormsModule } from '@angular/forms';
import { CreateBook } from '../../models/create-book';
@Component({
  selector: 'app-book-form',
  imports: [FormsModule],
  templateUrl: './book-form.html',
  styleUrl: './book-form.css',
})
export class BookForm {
  book: CreateBook = {
    title: '',
    author: '',
    publicationDate: '',
  };

  constructor(private bookService: BookService) {}

  addBook(): void {
    this.bookService.addBook(this.book).subscribe({
      next: (result) => {
        console.log('Book created:', result);
      },
      error: (error) => {
        console.error('Error creating book:', error);
      },
    });
  }
}
