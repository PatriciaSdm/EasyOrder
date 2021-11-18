import { Produto } from "./Produto";

export class ProdutoLista {
    constructor(category: string, products: Produto[]) {
        this.category = category;
        this.products = products;
    }
    category!: string;
    products!: Produto[]
}