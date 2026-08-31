import { Component, OnInit } from '@angular/core';
import { QuoteService } from '../../../services/quote-service';
import { Router } from '@angular/router';
import { QuoteResponse } from '../../../models/quote-response';
import { Navbar } from '../../../layout/navbar/navbar';

@Component({
  selector: 'app-quote-list',
  imports: [Navbar],
  templateUrl: './quote-list.html',
  styleUrl: './quote-list.css',
})
export class QuoteList implements OnInit {
  quotes: QuoteResponse[] = [];

  constructor(
    private quoteService: QuoteService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    console.log('quotelist added');

    this.quoteService.getMyQuotes().subscribe((quotes) => {
      console.log('Quotes loaded:', quotes);
      this.quotes = quotes;
    });
  }

  deleteQuote(quoteId: string): void {
    this.quoteService.deleteQuote(quoteId).subscribe({
      next: (result) => {
        console.log('Quote deleted:', result);
        this.quoteService.getMyQuotes().subscribe({
          next: (quotes) => {
            this.quotes = quotes;
          },
          error: (error) => {
            console.error('Error loading quotes:', error);
          },
        });
      },
      error: (error) => {
        console.error('Error deleting quotes:', error);
      },
    });

    this.router.navigate(['/quotes']);
  }

  addQuote(): void {
    this.router.navigate(['/quotes/add']);
  }

  updateQuote(quote: QuoteResponse): void {
    this.router.navigate(['/quotes/update', quote.id]);
  }
}
