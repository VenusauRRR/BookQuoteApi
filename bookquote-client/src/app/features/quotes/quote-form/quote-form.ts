import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateQuote } from '../../../models/create-quote';
import { QuoteService } from '../../../services/quote-service';
import { ActivatedRoute, Router } from '@angular/router';
import { QuoteResponse } from '../../../models/quote-response';
import { FormStyleDirective } from '../../../directives/form-style-directive';

@Component({
  selector: 'app-quote-form',
  imports: [FormsModule, FormStyleDirective],
  templateUrl: './quote-form.html',
  styleUrl: './quote-form.css',
})
export class QuoteForm implements OnInit {
  quoteId: string | null = null;
  quote: CreateQuote = {
    quoteText: ''
  };
  userId: string | null = null;

  constructor(
    private quoteService: QuoteService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.quoteId = this.route.snapshot.paramMap.get('quoteId');

    if (this.quoteId) {
      this.loadQuote(this.quoteId);
    }
  }

  loadQuote(id: string): void {
    this.quoteService.getQuoteById(id).subscribe({
      next: (quote) => {
        this.quote = {
          quoteText: quote.quoteText
        };
      },
      error: (error) => {
        console.error('Error loading quote:', error);
      },
    });
  }

  saveQuote(): void {
    this.quoteId ? this.updateQuote() : this.addQuote();
  }

  addQuote(): void {
    this.quoteService.addQuote(this.quote).subscribe({
      next: (result) => {
        console.log('Quote created:', result);
        this.router.navigate(['/quotes']);
      },
      error: (error) => {
        console.error('Error creating quote:', error);
      },
    });
  }

  updateQuote(): void {
    const quoteObjFrHtml: QuoteResponse = {
      id: this.quoteId!,
      quoteText: this.quote.quoteText
    };

    this.quoteService.updateQuote(quoteObjFrHtml).subscribe({
      next: (result) => {
        console.log('Quote updated:', result);
        this.router.navigate(['/quotes']);
      },
      error: (error) => {
        console.error('Error updating quote:', error);
      },
    });
  }
}
