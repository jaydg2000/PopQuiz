import { Component, OnInit, Input } from '@angular/core';
import { QuizSelection } from '../shared/quiz-selection.model';
import { QuizService } from '../shared/quiz-service/quiz.service';

@Component({
  selector: 'popquiz-edit-quiz',
  templateUrl: './edit-quiz.component.html',
  styleUrls: ['./edit-quiz.component.css']
})
export class EditQuizComponent implements OnInit {

  @Input() public quiz: QuizSelection;

  private _isEditMode = false;

  get isEditMode(): boolean {
    return this._isEditMode;
  }

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
  }

  public onEditQuizClick($event) {
    this._isEditMode = true;
  }

  public onEnter(quizName: string) {
    this._isEditMode = false;
    this.quiz.name = quizName;
    this._quizService.updateQuiz(this.quiz).subscribe(
      (success) => {},
      (error) => {}
    );
  }

  public cancelUpdate() {
    this._isEditMode = false;
  }
}
