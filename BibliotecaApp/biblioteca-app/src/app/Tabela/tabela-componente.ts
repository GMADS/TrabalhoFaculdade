import { Component, Input } from '@angular/core';

@Component({
  selector: 'tabela-componente',
  templateUrl: 'tabela-component.html',
})
export class TabelaComponent {
  @Input() dados: Array<{ id: number, nome: string }> | null = null;
}