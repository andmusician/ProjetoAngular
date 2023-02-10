export class Frase {
  public fraseEnglish!: string
  public frasePortuguese!: string

  constructor(fraseEng: string, frasePtBr: string) {
    this.fraseEnglish = fraseEng
    this.frasePortuguese = frasePtBr
  }
}
