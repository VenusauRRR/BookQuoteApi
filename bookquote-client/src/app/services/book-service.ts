import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { CreateBook } from '../models/create-book';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private apiUrl = 'http://localhost:5138/api/books';

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  getBookById(bookId: string): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/get/${bookId}`);
  }

  addBook(book: CreateBook): Observable<CreateBook> {
    return this.http.post<CreateBook>(`${this.apiUrl}/add`, book);
  }

  deleteBook(bookId: string): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl}/delete/${bookId}`);
  }

  updateBook(book: Book): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/update/${book.id}`, book);
  }
}
