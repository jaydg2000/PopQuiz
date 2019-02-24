import { Component, OnInit } from '@angular/core';
import { QuizService } from '../shared/quiz.service';
import { Quiz } from '../models/quiz';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public _quizes: Quiz[];

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
    this._quizes = this._quizService.getQuizes(1);
  }

}
