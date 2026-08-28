import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { CreateBook } from '../models/create-book';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private apiUrl = environment.apiUrl + '/books';


  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }

  getBookById(bookId: string): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/get/${bookId}`);
  }

  addBook(book: CreateBook): Observable<Book> {
    return this.http.post<Book>(`${this.apiUrl}/add`, book);
  }

  deleteBook(bookId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${bookId}`);
  }

  updateBook(book: Book): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/update/${book.id}`, book);
  }
}
