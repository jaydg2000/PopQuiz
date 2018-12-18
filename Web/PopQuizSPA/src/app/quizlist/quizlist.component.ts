import { Component, OnInit } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { DataService } from 'src/app/shared/dataservice/data.service';

@Component({
  selector: 'popquiz-quizlist',
  templateUrl: './quizlist.component.html',
  styleUrls: ['./quizlist.component.css']
})
export class QuizListComponent implements OnInit {

  private _quizes: QuizSelection[];
  private _showExpand: boolean;

  constructor(private _dataService: DataService) { }

  ngOnInit() {
    this._showExpand = true;
    this._dataService.getQuizes().subscribe(
      data => {
        this._quizes = data.quizSummaries;
      }
    );
  }

  private toggleExpandIcon() {
    this._showExpand = !this._showExpand;
  }
}
