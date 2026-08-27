import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book-service';
import { Book } from '../../models/book';
import { FormsModule } from '@angular/forms';
import { CreateBook } from '../../models/create-book';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-form',
  imports: [FormsModule],
  templateUrl: './book-form.html',
  styleUrl: './book-form.css',
})
export class BookForm implements OnInit {
  bookId: string | null = null;
  book: CreateBook = {
    title: '',
    author: '',
    publicationDate: '',
  };

  constructor(
    private bookService: BookService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.bookId = this.route.snapshot.paramMap.get('bookId');

    if (this.bookId) {
      this.loadBook(this.bookId);
    }
  }

  loadBook(id: string): void {
    this.bookService.getBookById(id).subscribe({
      next: (book) => {
        this.book = {
          title: book.title,
          author: book.author,
          publicationDate: book.publicationDate.split('T')[0],
        };
      },
      error: (error) => {
        console.error('Error loading book:', error);
      },
    });
  }

  saveBook(): void {
    this.bookId ? this.updateBook() : this.addBook();
    this.router.navigate(['/books']);
  }

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

  updateBook(): void {
    const bookObjFrHtml: Book = {
      id: this.bookId!,
      title: this.book.title,
      author: this.book.author,
      publicationDate: this.book.publicationDate,
    };

    this.bookService.updateBook(bookObjFrHtml).subscribe({
      next: (result) => {
        console.log('Book updated:', result);
      },
      error: (error) => {
        console.error('Error updating book:', error);
      },
    });
  }
}
