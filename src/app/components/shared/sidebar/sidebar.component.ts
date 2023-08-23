import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/service/usuario.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  constructor(
    private router : Router,
    private service : UsuarioService
    ) { }

  nome! : string | null
  id! : number | null

  ngOnInit(): void {
    this.estilizandoLogout()
    this.nome = localStorage?.getItem("nome")
    this.id = Number(localStorage?.getItem("id"))

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

  Logout(){
    localStorage.clear()
    this.router.navigate(["/login"])
  }

}