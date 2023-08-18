import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Lote } from 'src/app/interface/interfaces';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  @Input() lote! : Lote
  data! : Date
  @Output() changeboolean : EventEmitter<any> = new EventEmitter()



  constructor() { }

  ngOnInit(): void {
  }

  formataData(){
    this.data = new Date(this.lote.dt_Cadastro);
    return this.data.toLocaleDateString('pt-BR', {timeZone: 'UTC'});
  }

  mudarBoolean(){
    this.changeboolean.emit()
  }

}
