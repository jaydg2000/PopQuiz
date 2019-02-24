import { Injectable } from '@angular/core';
import { Quiz } from '../models/quiz';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  private _quizes: Quiz[] = [
    {
      id: 1,
      title: 'C# Programming Fundamentals',
      description: 'Test your knowledge in the world\'s most awesome programming language.'
    },
    {
      id: 2,
      title: 'COBOL Revisted',
      description: 'Can you remember what you learned in your COBOL class in school? Does it matter?'
    },
    {
      id: 3,
      title: 'C++ Primer',
      description: 'Do you have the basic C++ programming skills that all programmers should have?'
    },
    {
      id: 4,
      title: 'Java, Why it\'s bad!',
      description: 'Can you identify why Java is a horrible language and should be banished?'
    },
    {
      id: 5,
      title: 'Robot Hacking',
      description: 'What\'s your take on robot hacking?'
    },
    {
      id: 6,
      title: 'Healthy Cooking',
      description: 'Are you eating as healthly as you could be? Test your knowledge.'
    },
    {
      id: 7,
      title: 'Raspberry Pi Assembly Programming',
      description: 'How are you low level skills when it comes to programming the Raspberry Pi.'
    },
    {
      id: 8,
      title: 'Clean Architecture',
      description: 'Test your knowledge on writing code that is testable, maintainable and easy to read.'
    },
    {
      id: 9,
      title: 'Angular Fundamentals',
      description: 'Are you an expert with TypeScript and the Angular Framework?'
    },
    {
      id: 10,
      title: 'Gardening in the Desert',
      description: 'Test your expertise in growing food in the desert.'
    },
    {
      id: 11,
      title: 'Asynchronous Programming in C#',
      description: 'Threads, Tasks and Parallel Library.'
    },
  ];

  constructor() { }

  public getQuizes(page: number) {
    const itemsPerPage = 8;
    const start = (page - 1) * itemsPerPage;
    const end = start + 8;
    return this._quizes.slice(start, Math.min(this._quizes.length - 1, end));
  }
}
