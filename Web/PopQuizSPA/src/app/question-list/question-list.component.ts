import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from 'src/app/shared/question.model';
import { DataService } from 'src/app/shared/dataservice/data.service';

@Component({
  selector: 'popquiz-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  _showExpand: boolean;
  @Input() quizId: number;
  questions: Question[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this._showExpand = true;
  }

  public loadQuestions(event: any) {
    this.dataService.getQuestions(this.quizId).subscribe(
      data => {
        this.questions = data.questions;
      }
    );
  }
}
