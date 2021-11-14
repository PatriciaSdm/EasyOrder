import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Produto } from 'src/app/models/Produto';

@Component({
  selector: 'app-nova-comanda',
  templateUrl: './nova-comanda.component.html',
  styleUrls: ['./nova-comanda.component.scss']
})
export class NovaComandaComponent implements OnInit {
  step = 0;
  itemOpenState = false;
  descriptionOpenState = false;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;

  items!: Produto[];

  constructor(
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.beginForm();
  }

  beginForm() {
    this.firstFormGroup = this.fb.group({
      nome: ['', Validators.required],
      mesa: ['', Validators.required],
    });
    this.secondFormGroup = this.fb.group({
      itens: ['', Validators.required]
    });
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  adicionaItem(item: any) {
    console.log(item);
  }

}
