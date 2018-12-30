import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'popquiz-item-deleter',
  templateUrl: './item-deleter.component.html',
  styleUrls: ['./item-deleter.component.css']
})
export class ItemDeleterComponent implements OnInit {

  @Input() suffix: string;
  @Input() message: string;
  @Input() positiveButtonText = 'Yes';
  @Input() negativeButtonText = 'No';

  @Output() confirmed = new EventEmitter();
  @Output() dismissed = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  public onConfirmed() {
    this.confirmed.emit();
  }

  public onDismissed() {
    this.dismissed.emit();
  }

}
