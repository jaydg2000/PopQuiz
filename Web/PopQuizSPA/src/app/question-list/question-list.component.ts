import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { Question } from 'src/app/shared/question.model';
import { QuizService } from 'src/app/shared/quiz-service/quiz.service';
import { Choice } from '../shared/choice.model';
import { QuizSelection } from '../shared/quiz-selection.model';
import { ILabelEditorValueChanged } from '../shared/label-editor/label-editor-value-changed';

@Component({
  selector: 'popquiz-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  @Input() quizId: number;

  public questions: Question[];
  public showExpand = true;
  private _questionIdForDelete: number;

  constructor(private _quizService: QuizService) { }

  ngOnInit() {
  }

  public onToggleClick($event) {
    this.toggleExpand();
    if (this.questions == null) {
      this.loadQuestions();
    }
  }

  public onQuestionTextChanged($event: ILabelEditorValueChanged) {
    const question = $event.payload;
    question.text = $event.newValue;
    this._quizService.updateQuestion(this.quizId, question).subscribe();
  }

  public onAddQuestionClick() {
    const question = new Question();
    const rightChoice = new Choice();
    const wrongChoice = new Choice();

    question.id = 0;
    question.text = 'What is your new question?';
    rightChoice.id = 0;
    rightChoice.text = 'This is the right choice.';
    rightChoice.isCorrect = true;
    wrongChoice.id = 0;
    wrongChoice.text = 'This is the wrong choice.';
    wrongChoice.isCorrect = false;
    question.choices = [rightChoice, wrongChoice];

    this._quizService.createQuestion(this.quizId, question).subscribe(
      () => this.loadQuestions()
    );
  }

  private onDeleteQuestionClick(questionId: number) {
    this._questionIdForDelete = questionId;
  }

  private onDeleteQuestion() {
    this._quizService.deleteQuestion(this.quizId, this._questionIdForDelete).subscribe(
      () => this.loadQuestions()
    );
  }

  private loadQuestions() {
    this._quizService.getQuestions(this.quizId).subscribe(
      data => {
        this.questions = data.questions;
      }
    );
  }

  private toggleExpand() {
    this.showExpand = !this.showExpand;
  }
}
