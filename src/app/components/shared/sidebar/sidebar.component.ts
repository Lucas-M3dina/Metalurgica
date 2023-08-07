import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.estilizandoLogout()
  }

  estilizandoLogout(){
    const icone = document.getElementById("icon");
    const texto = document.getElementById("logout");
    const container = document.querySelector(".link-logout");


    container?.addEventListener("mouseover", () => {
      if (icone && texto) {
        icone.style.fill = 'red'
        texto.style.color = 'red'
      }

    });
    container?.addEventListener("mouseout", () => {
      if (icone && texto) {
        icone.style.fill = '#DADADA'
        texto.style.color = '#DADADA'
      }
    });

  }

}
