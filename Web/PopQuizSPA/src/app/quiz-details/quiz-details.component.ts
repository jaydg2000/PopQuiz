import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/shared/dataservice/data.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'popquiz-quiz-details',
  templateUrl: './quiz-details.component.html',
  styleUrls: ['./quiz-details.component.css']
})
export class QuizDetailsComponent implements OnInit {

  constructor(private _dataService: DataService) { }

  ngOnInit() {
  }

}
