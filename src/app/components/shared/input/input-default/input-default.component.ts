import { FormGroup } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-input-default',
  templateUrl: './input-default.component.html',
  styleUrls: ['./input-default.component.css']
})
export class InputDefaultComponent implements OnInit {

  @Input() labelInput : string = '';
  @Input() type : string = '';
  @Input() placeholder : string = '';
  @Input() formulario! : FormGroup;

  constructor() { }

  ngOnInit(): void {
  }

}
