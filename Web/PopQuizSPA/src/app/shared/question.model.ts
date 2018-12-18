import { Choice } from 'src/app/shared/choice.model';

export class Question {
  id: number;
  text: string;
  choices: Choice[];
}
