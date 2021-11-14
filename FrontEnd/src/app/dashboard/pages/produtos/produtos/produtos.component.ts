import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produtos.service';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {

  produtos: Produto[] = [];
  searchValue = "";

  constructor(
    private produtoService: ProdutoService,
  ) { }

  ngOnInit() {
    this.produtoService.get().subscribe(p => {
      this.produtos = p;
      this.produtoService.produtos$.next(p);
    });
  }

  deletarProduto(produtoId: number) {
    this.produtoService.delete(produtoId).subscribe();
  }

}
