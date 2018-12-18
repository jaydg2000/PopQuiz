import { Injectable } from '@angular/core';
import { QuizSelection } from 'src/app/shared/quiz-selection.model';
import { IGetQuizesResponse } from 'src/app/shared/dataservice/models/get-quizes-response.interface';
import { HttpClient } from '@angular/common/http';
import { Response } from 'selenium-webdriver/http';
import { Observable } from 'rxjs';
import { IGetQuestionsResponse } from 'src/app/shared/dataservice/models/get-questions-response.interface';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private _http: HttpClient) { }

  getQuizes(): Observable<IGetQuizesResponse> {
    return this._http.get('http://localhost:4201/api/quiz');
  }

  getQuestions(quizId: number): Observable<IGetQuestionsResponse> {
    return this._http.get('http://localhost:4201/api/quiz/' + quizId + '/question');
  }
}
