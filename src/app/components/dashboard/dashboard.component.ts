import { Component, OnInit } from '@angular/core';
import { LoteService } from 'src/app/service/lote.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  contagem : number = 0

  constructor(private service : LoteService) { }

  ngOnInit(): void {
    this.ContagemLote()
  }

  ContagemLote() {
    this.service.ListarLote().subscribe(
      (response) => {
        this.contagem =  response.length
      },
      () => {
        localStorage.clear()
      }
    );
  }


}
