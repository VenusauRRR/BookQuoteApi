import { AfterViewInit, Directive, ElementRef } from '@angular/core';


@Directive({
  selector: 'form'
})
export class FormStyleDirective implements AfterViewInit {
  constructor(private el: ElementRef){
    
  }
    ngAfterViewInit(): void {

      const textareas = this.el.nativeElement.querySelectorAll('textarea');
      const labels = this.el.nativeElement.querySelectorAll('label');
      const buttons = this.el.nativeElement.querySelectorAll('button');

      textareas.forEach((textarea: HTMLElement) => {
        textarea.classList.add('form-control');
      });

      labels.forEach((label: HTMLElement) => {
        label.classList.add('d-block');
      });

      buttons.forEach((button: HTMLElement) => {
        button.classList.add('mt-2');
      });
    }
}
