export class UpdateChoiceRequest {
  quizId: number;
  choiceId: number;
  questionId: number;
  text: string;
  isCorrect: boolean;
}
