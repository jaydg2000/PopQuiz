import { Component, OnInit } from '@angular/core';
import { Choice } from 'src/app/shared/choice.model';
import { Input } from '@angular/core';

@Component({
  selector: 'popquiz-choice-list',
  templateUrl: './choice-list.component.html',
  styleUrls: ['./choice-list.component.css']
})
export class ChoiceListComponent implements OnInit {

  @Input() choices: Choice[];

  constructor() { }

  ngOnInit() {
  }


}
