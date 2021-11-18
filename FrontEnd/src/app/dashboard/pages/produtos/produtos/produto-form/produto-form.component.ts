import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produtos.service';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.scss']
})
export class ProdutoFormComponent implements OnInit {

  produtoId!: any;
  produto!: Produto;

  searchValue = "";
  isLinear = false;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  thirdFormGroup!: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private produtoService: ProdutoService
  ) { }

  ngOnInit() {
    this.beginForm();

    this.produtoId = this.route.snapshot.params['produtoId'];
    if (this.produtoId && this.produtoId === "0") {
      this.produto = new Produto();
    } else {
      this.produtoService.getById(this.produtoId).subscribe(p => {
        this.produto = p;
        this.populaForm();
      });
    }
  }

  beginForm() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.thirdFormGroup = this._formBuilder.group({
      thirdCtrl: ['', Validators.required]
    });
  }

  populaForm() {
    this.firstFormGroup.get('firstCtrl')?.setValue(this.produto.name);
    this.secondFormGroup.get('secondCtrl')?.setValue(this.produto.category);
    this.thirdFormGroup.get('thirdCtrl')?.setValue(this.produto.description);
  }

  handlerActionProduto() {
    if (this.produtoId === "0") {
      let produto = new Produto();

      produto.name = this.firstFormGroup.get('firstCtrl')?.value;
      produto.category = this.secondFormGroup.get('secondCtrl')?.value;
      produto.description = this.thirdFormGroup.get('thirdCtrl')?.value;

      this.produtoService.insert(produto).subscribe(res => {
        console.log(res);
      });
    } else {
      let produto = new Produto();

      produto.name = this.firstFormGroup.get('firstCtrl')?.value;
      produto.category = this.secondFormGroup.get('secondCtrl')?.value;
      produto.description = this.thirdFormGroup.get('thirdCtrl')?.value;
      produto.id = this.produtoId;

      this.produtoService.update(produto).subscribe(res => {
        console.log(res);
      });
    }

    // verificar se é salvar ou editar antes de enviar a requisição
    // se tiver o id já no banco é update , senão é insert

  }
}
