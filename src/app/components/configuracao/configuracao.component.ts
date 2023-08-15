import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/service/usuario.service';

@Component({
  selector: 'app-configuracao',
  templateUrl: './configuracao.component.html',
  styleUrls: ['./configuracao.component.css']
})
export class ConfiguracaoComponent implements OnInit {

  formulario!: FormGroup;
  loading : boolean = false

  constructor(private service: UsuarioService, private formBuilder : FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      Email : ['', [Validators.required, Validators.email]],
      Senha : ['', [Validators.required]],
      Nome : ['', [Validators.required]],
      Confirme : ['', [Validators.required]],
    })


  }

  AtualizarUsuario(){
    this.loading = true

    const email = this.formulario.controls['Email']?.value
    const senha = this.formulario.controls['Senha']?.value
    const nome = this.formulario.controls['Nome']?.value

    this.service.Cadastrar(nome, email, senha).subscribe(
      () => {
        this.loading = false
        alert('Usuario Atualizado')
      },
      () => {
        this.loading = false
      });

  }

}
