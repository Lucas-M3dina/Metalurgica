import { Component, OnInit } from '@angular/core';
import { Lote } from 'src/app/interface/interfaces';
import { LoteService } from 'src/app/service/lote.service';

@Component({
  selector: 'app-listagem-lote',
  templateUrl: './listagem-lote.component.html',
  styleUrls: ['./listagem-lote.component.css']
})
export class ListagemLoteComponent implements OnInit {

  lotes! : Lote[]
  loteSelecionado! : Lote
  selecionado : boolean = false
  data! : Date

  constructor(private service : LoteService) { }

  ngOnInit(): void {
    this.Listar()
  }

  Listar(){
    this.service.ListarLote().subscribe(
      (response) => {

        this.lotes = response

        console.log(this.lotes);
      },
      () => {

      });
  }

  onChangeBoolean(id : number){
    this.selecionado = true
    this.service.GetLote(id).subscribe(
      (response) => {
        console.log(response);
        this.loteSelecionado = response
      }
    )
  }

  formataData(){
    this.data = new Date(this.loteSelecionado.dt_Cadastro);
    return this.data.toLocaleDateString('pt-BR', {timeZone: 'UTC'});
  }

}
