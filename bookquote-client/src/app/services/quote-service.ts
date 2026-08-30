import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuoteResponse } from '../models/quote-response';
import { CreateQuote } from '../models/create-quote';

@Injectable({
  providedIn: 'root',
})
export class QuoteService {
  private apiUrl = environment.apiUrl + '/quotes';


  constructor(private http: HttpClient) { }

  // getQuotes(): Observable<Quote[]> {
  //   return this.http.get<Quote[]>(this.apiUrl);
  // }

  getMyQuotes(): Observable<QuoteResponse[]> {
    return this.http.get<QuoteResponse[]>(`${this.apiUrl}/get-my-quotes`);
  }

  getQuoteById(quoteId: string): Observable<QuoteResponse> {
    return this.http.get<QuoteResponse>(`${this.apiUrl}/get/${quoteId}`);
  }

  addQuote(quote: CreateQuote): Observable<QuoteResponse> {
    return this.http.post<QuoteResponse>(`${this.apiUrl}/add`, quote);
  }

  deleteQuote(quoteId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${quoteId}`);
  }

  updateQuote(quote: QuoteResponse): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/update/${quote.id}`, quote);
  }
}
