import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/service/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formulario! : FormGroup

  constructor(
    private formBuilder : FormBuilder,
    private service: UsuarioService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      Email : [''],
      Senha : ['']
    })
  }

  login() : void{
    const email = this.formulario.controls['Email']?.value
    const senha = this.formulario.controls['Senha']?.value

    this.service.Login(email, senha).subscribe(
      (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(["/dashboard"])
      },
      () => {
        localStorage.clear()
      }
    )
  }

}
