import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { TextAreaComponent } from '../../components/text-area/text-area.component';
import { ButtonComponent } from '../../components/button/button.component';
import { TableComponent } from '../../components/table/table.component';
import { ModalComponent } from '../../components/modal/modal.component';
import { Tb01Service } from '../../services/tb01.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TB01 } from '../../models/tb01.model';
import { AsyncPipe, CommonModule, NgIf } from '@angular/common';
import { Observable } from 'rxjs';
import { PdfService } from '../../services/pdf.service';

interface RegisterForm {
  colText: FormControl;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    TextAreaComponent,
    ButtonComponent,
    TableComponent,
    ModalComponent,
    ReactiveFormsModule,
    AsyncPipe,
    NgIf,
    CommonModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  registerForm!: FormGroup<RegisterForm>;
  modalVisibility: boolean = false;
  tb01$!: Observable<TB01[]>;
  idFoUpdate!: number;
  constructor(
    private tb01Service: Tb01Service,
    private toastr: ToastrService,
    private pdf: PdfService
  ) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      colText: new FormControl('', Validators.required),
    });

    this.tb01$ = this.tb01Service.getAll();
  }

  openModal(id: number) {
    this.modalVisibility = true;
    this.idFoUpdate = id;
  }
  closeModal() {
    this.modalVisibility = false;
  }

  private refreshList() {
    this.tb01$ = this.tb01Service.getAll();
  }

  onSubmit() {
    if (this.registerForm.valid) {
      const tb01: TB01 = {
        colText: this.registerForm.value.colText,
      };

      this.tb01Service.create(tb01).subscribe({
        next: () => {
          this.toastr.success('Registro efetuado com sucesso');
          this.refreshList();
        },
        error: (error) => {
          console.error(error);
          this.toastr.error('Ocorreu um erro ao fazer o registro');
        },
      });
    } else {
      this.toastr.error('Insira o texto');
    }
  }

  onDeleteSubmit(id: number) {
    const tb01: TB01 = {
      id,
    };

    this.tb01Service.delete(tb01).subscribe({
      next: () => {
        this.toastr.success('Registro eliminado com sucesso');
        this.refreshList();
      },
      error: () =>
        this.toastr.error('Ocorreu um erro ao fazer ao eliminar registro'),
    });
  }

  onUpdateSubmit(id: number) {
    this.closeModal();
    if (this.registerForm.valid) {
      const tb01: TB01 = {
        id,
        colText: this.registerForm.value.colText,
      };

      this.tb01Service.update(tb01).subscribe({
        next: () => {
          this.toastr.success('Registro atualizado com sucesso');
          this.refreshList();
        },
        error: () =>
          this.toastr.error('Ocorreu um erro ao atualizar o registro'),
      });
      this.registerForm.reset();
    } else {
      this.toastr.error('Insira o texto');
    }
  }

  downloadPdf(tb01: TB01[]) {
    this.pdf.generatePdf(tb01);
    console.log('sdsjfsd');
  }
}
