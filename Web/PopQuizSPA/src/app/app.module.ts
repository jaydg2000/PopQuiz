import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {RouterModule} from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { QuizListComponent } from './quiz-list/quiz-list.component';
import { HttpClientModule } from '@angular/common/http';
import { QuizDetailsComponent } from './quiz-details/quiz-details.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { ChoiceListComponent } from './choice-list/choice-list.component';
import { EditQuizComponent } from './edit-quiz/edit-quiz.component';
import { EditChoiceComponent } from './edit-choice/edit-choice.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    QuizListComponent,
    QuizDetailsComponent,
    QuestionListComponent,
    ChoiceListComponent,
    EditQuizComponent,
    EditChoiceComponent,
    EditQuestionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'dash', component: DashboardComponent},
      {path: 'quizes', component: QuizListComponent}
    ], {useHash: false})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
