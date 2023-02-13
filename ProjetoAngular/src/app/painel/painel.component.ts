import { Component } from '@angular/core';

import { Frase } from '../shared/frase.model'
import { FRASES } from './frases-mock'

@Component({
  selector: 'app-painel',
  templateUrl: './painel.component.html',
  styleUrls: ['./painel.component.css']
})
export class PainelComponent {

  public frases: Frase[] = FRASES

  public instrucao : string = 'Translate the phrase'

  constructor() { console.log(this.frases) }

  public atualizaResposta(): void {
    console.log('teste')
  }

}
