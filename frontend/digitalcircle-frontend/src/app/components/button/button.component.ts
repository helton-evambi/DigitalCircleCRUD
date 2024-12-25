import { Component, EventEmitter, Input, Output } from '@angular/core';

type BtnVariants = 'primary' | 'secondary' | 'danger';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.scss',
})
export class ButtonComponent {
  @Input('btn-text') btnText: string = '';
  @Input() variant: BtnVariants = 'primary';
  @Output('submit') onSubmit = new EventEmitter();

  submit() {
    this.onSubmit.emit();
  }
}
