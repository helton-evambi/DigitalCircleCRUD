import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss',
})
export class ModalComponent {
  @Input() title: string = '';
  @Input() visibility: boolean = false;
  @Output() closeModal = new EventEmitter<void>();
  close() {
    this.closeModal.emit();
  }
}
