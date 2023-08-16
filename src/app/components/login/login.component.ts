import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/service/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formulario! : FormGroup
  msgErro! : string

  loading : boolean = false

  constructor(
    private formBuilder : FormBuilder,
    private service: UsuarioService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      Email : ['', [Validators.required, Validators.email]],
      Senha : ['', [Validators.required]]
    })
  }

  login() : void{
    const email = this.formulario.controls['Email']?.value
    const senha = this.formulario.controls['Senha']?.value
    this.loading = true

    this.service.Login(email, senha).subscribe(
      (response) => {
        localStorage.setItem('token', response.token);
        this.GetMe()

        this.router.navigate(["/dashboard"])
        this.loading = false
      },
      () => {
        localStorage.clear()

        setTimeout(()=> {
          this.loading = false
          this.msgErro = 'Algo deu errado, verifique seu email e sua senha e tente novamente'
        }, 2000)
      }
    )
  }

  GetMe(){
    this.service.GetMe().subscribe(
      (response) => {
        localStorage.setItem('nome', response.nome);
        localStorage.setItem('id', response.idTipoUsuario.toString());
        localStorage.setItem('email', response.email);

      },
      () => {

      }
    )
  }



}
