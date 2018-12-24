import { Component, OnInit } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { QuizService } from 'src/app/shared/quiz-service/quiz.service';
import { Question } from '../shared/question.model';
import { Choice } from '../shared/choice.model';
import { ILabelEditorValueChanged } from '../shared/label-editor/label-editor-value-changed';

@Component({
  selector: 'popquiz-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})
export class QuizListComponent implements OnInit {

  public quizes: QuizSelection[];

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
    this._quizService.getQuizes().subscribe(
      data => {
        this.quizes = data.quizSummaries;
      }
    );
  }

  public onQuizTextChanged($event: ILabelEditorValueChanged) {
    const quiz = $event.payload;
    quiz.name = $event.newValue;
    this._quizService.updateQuiz(quiz).subscribe(
      (success) => {},
      (error) => {}
    );
  }
}
