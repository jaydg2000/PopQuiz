import { AddQuestionChoiceRequest } from './add-question-choice-request';

export class AddQuestionRequest {
  quizId: number;
  text: string;
  answers: AddQuestionChoiceRequest[];
}
