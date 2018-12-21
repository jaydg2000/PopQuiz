import { Component, OnInit, Input } from '@angular/core';
import { Question } from '../shared/question.model';
import { QuizService } from '../shared/quiz-service/quiz.service';

@Component({
  selector: 'popquiz-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.css']
})
export class EditQuestionComponent implements OnInit {

  @Input() question: Question;
  @Input() quizId: number;

  private _isEditMode = false;

  get isEditMode(): boolean {
    return this._isEditMode;
  }

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
  }

  public onEditQuestionClick($event) {
    this._isEditMode = true;
  }

  public onEnter(questionText: string) {
    this._isEditMode = false;
    this.question.text = questionText;
    this._quizService.updateQuestion(this.quizId, this.question).subscribe();
  }

  public cancelUpdate() {
    this._isEditMode = false;
  }
}
