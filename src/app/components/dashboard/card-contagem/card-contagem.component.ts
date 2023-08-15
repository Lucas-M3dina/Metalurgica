import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-contagem',
  templateUrl: './card-contagem.component.html',
  styleUrls: ['./card-contagem.component.css']
})
export class CardContagemComponent implements OnInit {

  @Input() srcImagem! : string
  @Input() titulo! : string
  @Input() numeroContagem! : number

  constructor() { }

  ngOnInit(): void {
  }

}
