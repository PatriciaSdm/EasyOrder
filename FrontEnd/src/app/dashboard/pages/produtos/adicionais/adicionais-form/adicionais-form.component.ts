import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-adicionais-form',
  templateUrl: './adicionais-form.component.html',
  styleUrls: ['./adicionais-form.component.scss']
})
export class AdicionaisFormComponent implements OnInit {

  searchValue = "";
  isLinear = false;
  firstFormGroup!: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
  }

}
