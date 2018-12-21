import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from 'src/app/shared/question.model';
import { QuizService } from 'src/app/shared/quiz-service/quiz.service';

@Component({
  selector: 'popquiz-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  @Input() quizId: number;

  questions: Question[];
  showExpand = true;

  constructor(private quizService: QuizService) { }

  ngOnInit() {
  }

  public onToggleClick($event) {
    this.toggleExpand();
    if (this.questions == null) {
      this.loadQuestions();
    }
  }

  private loadQuestions() {
    this.quizService.getQuestions(this.quizId).subscribe(
      data => {
        this.questions = data.questions;
      }
    );
  }

  private toggleExpand() {
    this.showExpand = !this.showExpand;
  }
}
