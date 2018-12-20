import { Component, OnInit } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { DataService } from 'src/app/shared/dataservice/data.service';

@Component({
  selector: 'popquiz-quizlist',
  templateUrl: './quizlist.component.html',
  styleUrls: ['./quizlist.component.css']
})
export class QuizListComponent implements OnInit {

  public quizes: QuizSelection[];
  // public showExpand: boolean;

  constructor(private _dataService: DataService) { }

  ngOnInit() {
    // this.showExpand = true;
    this._dataService.getQuizes().subscribe(
      data => {
        this.quizes = data.quizSummaries;
      }
    );
  }

  // private toggleExpandIcon() {
  //   this.showExpand = !this.showExpand;
  // }
}
