import { AddChoiceRequest } from './add-question-choice-request';

export class AddQuestionRequest {
  quizId: number;
  text: string;
  answers: AddChoiceRequest[];
}
