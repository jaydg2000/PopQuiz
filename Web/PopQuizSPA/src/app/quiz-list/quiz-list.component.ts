import { Component, OnInit } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { QuizService } from 'src/app/shared/quiz-service/quiz.service';

@Component({
  selector: 'popquiz-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})
export class QuizListComponent implements OnInit {

  public quizes: QuizSelection[];

  constructor(private _dataService: QuizService) { }

  ngOnInit() {
    this._dataService.getQuizes().subscribe(
      data => {
        this.quizes = data.quizSummaries;
      }
    );
  }
}
