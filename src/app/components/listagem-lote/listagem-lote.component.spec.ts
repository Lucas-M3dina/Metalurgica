import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemLoteComponent } from './listagem-lote.component';

describe('ListagemLoteComponent', () => {
  let component: ListagemLoteComponent;
  let fixture: ComponentFixture<ListagemLoteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListagemLoteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListagemLoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
