import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemDeleterComponent } from './item-deleter.component';

describe('ItemDeleterComponent', () => {
  let component: ItemDeleterComponent;
  let fixture: ComponentFixture<ItemDeleterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemDeleterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemDeleterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
