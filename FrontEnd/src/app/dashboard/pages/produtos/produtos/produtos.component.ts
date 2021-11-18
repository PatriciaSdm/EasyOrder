import { Component, OnInit } from '@angular/core';
import { Produto } from 'src/app/models/Produto';
import { ProdutoLista } from 'src/app/models/ProdutoLista';
import { ProdutoService } from 'src/app/services/produtos.service';
import { groupBy } from 'src/app/utils/array';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {

  produtos: Produto[] = [];
  produtosLista!: ProdutoLista[];

  constructor(
    private produtoService: ProdutoService,
  ) { }

  ngOnInit() {
    this.produtoService.get().subscribe(p => {
      this.produtos = p;
      const productsGrouped = groupBy(this.produtos, p => p.category.name);
      this.produtosLista = this.mapToProdutoLista(productsGrouped);
    });
  }

  deletarProduto(produtoId: number) {
    this.produtoService.delete(produtoId).subscribe();
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
