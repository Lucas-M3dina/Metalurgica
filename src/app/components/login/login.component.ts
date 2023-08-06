import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formulario! : FormGroup

  constructor(
    private formBuilder : FormBuilder
  ) { }

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      Email : [''],
      Senha : ['']
    })
  }

  login() : void{
    console.log(this.formulario);
  }

}
