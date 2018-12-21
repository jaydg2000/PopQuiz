import { Component, OnInit, Input } from '@angular/core';
import { Choice } from '../shared/choice.model';
import { QuizService } from '../shared/quiz-service/quiz.service';

@Component({
  selector: 'popquiz-edit-choice',
  templateUrl: './edit-choice.component.html',
  styleUrls: ['./edit-choice.component.css']
})
export class EditChoiceComponent implements OnInit {

  @Input() public quizId: number;
  @Input() public questionId: number;
  @Input() public choice: Choice;

  private _isEditMode = false;

  get isEditMode(): boolean {
    return this._isEditMode;
  }

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
  }

  public onEditChoiceClick($event) {
    this._isEditMode = true;
  }

  public cancelUpdate() {
    this._isEditMode = false;
  }

  public onEnter(choiceText: string) {
    this._isEditMode = false;
    this.choice.text = choiceText;
    this._quizService.updateChoice(this.quizId, this.questionId, this.choice).subscribe(
      (success) => {},
      (error) => {}
    );
  }
}
