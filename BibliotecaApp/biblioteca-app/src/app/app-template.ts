import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})
export class AppComponent  {
  dados: Array<{ id: number, nome: string }> = [];
dados: any;

  constructor() {
    this.dados = [{
      "id": 442,
      "nome": "Myrtle"
    }, {
      "id": 376,
      "nome": "Georgette"
    }, {
      "id": 882,
      "nome": "Manning"
    }, {
      "id": 414,
      "nome": "Essie"
    }, {
      "id": 466,
      "nome": "Augusta"
    }, {
      "id": 315,
      "nome": "Mueller"
    }, {
      "id": 344,
      "nome": "Walter"
    }];
  };
}