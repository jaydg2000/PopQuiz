import { Component, OnInit } from '@angular/core';
import { QuizService } from 'src/app/shared/dataservice/quiz.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'popquiz-quiz-details',
  templateUrl: './quiz-details.component.html',
  styleUrls: ['./quiz-details.component.css']
})
export class QuizDetailsComponent implements OnInit {

  constructor(private _dataService: QuizService) { }

  ngOnInit() {
  }

}
