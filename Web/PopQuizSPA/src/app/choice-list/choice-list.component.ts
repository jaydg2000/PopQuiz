import { Component, OnInit } from '@angular/core';
import { Choice } from 'src/app/shared/choice.model';
import { Input } from '@angular/core';
import { QuizService } from '../shared/quiz-service/quiz.service';
import { ILabelEditorValueChanged } from '../shared/label-editor/label-editor-value-changed';

@Component({
  selector: 'popquiz-choice-list',
  templateUrl: './choice-list.component.html',
  styleUrls: ['./choice-list.component.css']
})
export class ChoiceListComponent implements OnInit {

  @Input() public quizId: number;
  @Input() public questionId: number;
  @Input() public choices: Choice[];

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
  }

  public toggleCorrectness(choice: Choice) {
    choice.isCorrect = !choice.isCorrect;
    this._quizService.updateChoice(this.quizId, this.questionId, choice).subscribe();
  }

  public onAddChoiceClick() {
    const choice = new Choice();
    choice.id = 0;
    choice.text = 'New choice';
    choice.isCorrect = false;
    this._quizService.createChoice(this.quizId, this.questionId, choice).subscribe(
      (data) => {
        choice.id = data['newChoiceId'];
        this.choices.push( choice );
      }
    );
  }

  public onChoiceTextChanged($event: ILabelEditorValueChanged) {
    const choice = $event.payload;
    choice.text = $event.newValue;
    this._quizService.updateChoice(this.quizId, this.questionId, choice).subscribe(
      (success) => {},
      (error) => {}
    );
  }
}
