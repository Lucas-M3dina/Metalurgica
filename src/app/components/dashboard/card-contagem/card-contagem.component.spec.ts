import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardContagemComponent } from './card-contagem.component';

describe('CardContagemComponent', () => {
  let component: CardContagemComponent;
  let fixture: ComponentFixture<CardContagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardContagemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardContagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
