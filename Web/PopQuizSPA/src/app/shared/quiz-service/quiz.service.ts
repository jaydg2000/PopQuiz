import { Injectable } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { IGetQuizesResponse } from 'src/app/shared/quiz-service/models/get-quizes-response.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGetQuestionsResponse } from 'src/app/shared/quiz-service/models/get-questions-response.interface';
import { Choice } from '../choice.model';
import { UpdateChoiceRequest } from './models/update-choice-request';
import { UpdateQuestionRequest } from './models/update-question-request';
import { Question } from '../question.model';
import { AddQuestionRequest } from './models/add-question-request';
import { AddQuestionChoiceRequest } from './models/add-question-choice-request';
import { AddChoiceRequest } from './models/add-choice-request';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private _http: HttpClient) { }

  getQuizes(): Observable<IGetQuizesResponse> {
    return this._http.get<IGetQuizesResponse>('http://localhost:4201/api/quiz');
  }

  getQuestions(quizId: number): Observable<IGetQuestionsResponse> {
    return this._http.get<IGetQuestionsResponse>('http://localhost:4201/api/quiz/' + quizId + '/question');
  }

  updateQuiz(updatedQuiz: QuizSelection): Observable<QuizSelection> {
    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this._http.put<QuizSelection>('http://localhost:4201/api/quiz/' + updatedQuiz.id, updatedQuiz, options);
  }

  updateQuestion(quizId: number, updatedQuestion: Question): Observable<Question> {
    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this._http.put<Question>(
      'http://localhost:4201/api/quiz/' + quizId + '/question/' + updatedQuestion.id,
      this.buildUpdateQuestionRequest(quizId, updatedQuestion),
      options);
  }

  createQuestion(quizId: number, question: Question): Observable<AddQuestionRequest> {
    const choice1 = new AddQuestionChoiceRequest();
    choice1.text = question.choices[0].text;
    choice1.isCorrect = question.choices[0].isCorrect;
    const choice2 = new AddQuestionChoiceRequest();
    choice2.text = question.choices[1].text;
    choice2.isCorrect = question.choices[1].isCorrect;

    const request = new AddQuestionRequest();
    request.quizId = quizId;
    request.text = question.text;
    request.answers = [choice1, choice2];

    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};

    return this._http.post<AddQuestionRequest>(
      'http://localhost:4201/api/quiz/' + quizId + '/question/',
      request,
      options);
  }

  deleteQuestion(quizId: number, questionId: number): Observable<{}> {
    return this._http.delete('http://localhost:4201/api/quiz/' + quizId + '/question/' + questionId);
  }

  createChoice(quizId: number, questionId: number, choice: Choice): Observable<{}> {
    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this._http.post(
      'http://localhost:4201/api/quiz/' + quizId + '/question/' + questionId + '/choice/',
      this.buildAddChoiceRequest(quizId, questionId, choice));
  }

  updateChoice(quizId: number, questionId: number, updatedChoice: Choice): Observable<Choice> {
    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this._http.put<Choice>(
      'http://localhost:4201/api/quiz/' + quizId + '/question/' + questionId + '/choice/' + updatedChoice.id,
      this.buildUpdateChoiceRequest(quizId, questionId, updatedChoice),
      options);
  }

  deleteChoice(quizId: number, questionId: number, choiceId: number): Observable<{}> {
    return this._http.delete('http://localhost:4201/api/quiz/' + quizId + '/question/' + questionId + '/choice/' + choiceId);
  }

  private buildUpdateQuestionRequest(quizId: number, question: Question) {
    const request = new UpdateQuestionRequest();
    request.quizId = quizId;
    request.questionId = question.id;
    request.newText = question.text;
    return request;
  }

  private buildUpdateChoiceRequest(quizId: number, questionId: number, updatedChoice: Choice) {
    const request = new UpdateChoiceRequest();
    request.quizId = quizId;
    request.questionId = questionId;
    request.choiceId = updatedChoice.id;
    request.text = updatedChoice.text;
    request.isCorrect = updatedChoice.isCorrect;
    return request;
  }

  private buildAddChoiceRequest(quizId: number, questionId: number, choice: Choice) {
    const request = new AddChoiceRequest();
    request.quizId = quizId;
    request.questionId = questionId;
    request.text = choice.text;
    request.isCorrect = choice.isCorrect;
    return request;
  }
}
