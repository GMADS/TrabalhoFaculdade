import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TabelaModule } from './Tabela/tabela-module';

@NgModule({
  declarations: [AppComponent ],
  bootstrap: [AppComponent],
  imports: [ BrowserModule, FormsModule, TabelaModule ],
})
export class AppModule { 

}