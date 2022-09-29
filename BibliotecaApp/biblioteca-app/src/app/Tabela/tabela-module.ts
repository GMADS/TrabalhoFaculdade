import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabelaComponent } from './tabela-componente';

@NgModule({
  declarations: [TabelaComponent],
  exports: [TabelaComponent],
  imports: [CommonModule],
})
export class TabelaModule {

}