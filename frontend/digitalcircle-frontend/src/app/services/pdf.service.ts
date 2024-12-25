import { Injectable } from '@angular/core';
import { TB01 } from '../models/tb01.model';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

@Injectable({
  providedIn: 'root',
})
export class PdfService {
  generatePdf(registros: TB01[]) {
    const doc = new jsPDF();

    doc.setFont('helvetica', 'bold');
    doc.setTextColor('#FF6B18');
    doc.setFontSize(24);
    doc.text('Digital Circle', 10, 10);

    autoTable(doc, {
      head: [['ID', 'Texto', 'Data']],
      body: registros.map((reg) => [
        String(reg.id),
        String(reg.colText),
        String(reg.colDt),
      ]),
      styles: {
        halign: 'center',
        valign: 'middle',
        fillColor: '#FFF3E9',
        textColor: '#FF6B18',
      },
      headStyles: {
        fillColor: '#FF6B18',
        textColor: '#FFFFFF',
        fontSize: 12,
      },
    });

    doc.save('DigitalCircle.pdf');
  }
}
