import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/service/usuario.service';
import {passwordMatch } from 'src/app/validator/confirmaSenha.validator';
import { DialogOkComponent } from '../shared/dialog/dialog-ok/dialog-ok.component';

@Component({
  selector: 'app-configuracao',
  templateUrl: './configuracao.component.html',
  styleUrls: ['./configuracao.component.css']
})
export class ConfiguracaoComponent implements OnInit {

  formulario!: FormGroup;
  loading : boolean = false

  msgErro : string = ""

  nome! : string | null
  email! : string | null

  constructor(private service: UsuarioService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.nome = localStorage?.getItem("nome")
    this.email = localStorage?.getItem("email")

    this.formulario = new FormGroup({
      Email : new FormControl(this.email, [Validators.required, Validators.email]),
      Senha : new FormControl("", [Validators.required]),
      Nome : new FormControl(this.nome, [Validators.required]),
      Confirme : new FormControl("", [Validators.required]),
    }, [passwordMatch("Senha","Confirme")])

  }

  AtualizarUsuario(){
    this.loading = true
    const email = this.formulario.controls['Email']?.value
    const senha = this.formulario.controls['Senha']?.value
    const nome = this.formulario.controls['Nome']?.value

    this.service.Cadastrar(nome, email, senha).subscribe(
      () => {
        this.loading = false
        this.msgErro = ""
        this.pushMessage()
      },
      () => {

        this.loading = false
        this.msgErro = "Algo deu errado, tente novamente mais tarde"
      });
  }

  pushMessage(){
    const dialogRef = this.dialog.open(DialogOkComponent, {
      panelClass: 'dialog-container'
    })
  }



}
