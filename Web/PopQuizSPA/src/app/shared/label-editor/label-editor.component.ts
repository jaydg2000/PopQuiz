import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ILabelEditorValueChanged } from './label-editor-value-changed';

@Component({
  selector: 'popquiz-label-editor',
  templateUrl: './label-editor.component.html',
  styleUrls: ['./label-editor.component.css']
})
export class LabelEditorComponent implements OnInit {

  @Input() value: string;
  @Input() payload: any;

  @Output() valueChanged = new EventEmitter<ILabelEditorValueChanged>;
  @Output() cancelChange = new EventEmitter<{}>;

  private _isEditMode = false;

  get isEditMode(): boolean {
    return this._isEditMode;
  }

  constructor() { }

  ngOnInit() {
  }

  public show($event) {
    this._isEditMode = true;
  }

  public onEnter(value: string) {
    this._isEditMode = false;
    this.valueChanged.emit({
      newValue: value,
      payload: this.payload
    });
  }

  public onCancel() {
    this._isEditMode = false;
    this.cancelChange.emit();
  }
}
