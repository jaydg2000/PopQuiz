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

  updateChoice(quizId: number, questionId: number, updatedChoice: Choice): Observable<Choice> {
    const options = { headers: new HttpHeaders({ 'Content-Type': 'application/json'})};
    return this._http.put<Choice>(
      'http://localhost:4201/api/quiz/' + quizId + '/question/' + questionId + '/choice/' + updatedChoice.id,
      this.buildUpdateChoiceRequest(quizId, questionId, updatedChoice),
      options);
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

}
