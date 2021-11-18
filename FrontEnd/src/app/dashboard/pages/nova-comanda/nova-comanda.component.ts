import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Produto } from 'src/app/models/Produto';
import { ProdutoLista } from 'src/app/models/ProdutoLista';
import { ProdutoService } from 'src/app/services/produtos.service';
import { groupBy } from 'src/app/utils/array';


@Component({
  selector: 'app-nova-comanda',
  templateUrl: './nova-comanda.component.html',
  styleUrls: ['./nova-comanda.component.scss']
})
export class NovaComandaComponent implements OnInit {
  step = 0;
  itemOpenState = false;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  produtos: Produto[] = [];
  produtosLista!: ProdutoLista[];

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService
  ) { }

  ngOnInit(): void {
    this.beginForm();
    this.produtoService.get().subscribe(p => {
      this.produtos = p;
      const productsGrouped = groupBy(this.produtos, p => p.category.name);
      this.produtosLista = this.mapToProdutoLista(productsGrouped);
    });
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

  private mapToProdutoLista(productsGrouped: Record<string, Produto[]>) {
    return Object.keys(productsGrouped).map(function (key) {
      return new ProdutoLista(key, productsGrouped[key]);
    });
  }

  openDescription(produto: any) {
    produto.showDescription = !produto.showDescription;
  }

}
