export class Produto {
    id!: string;
    name!: string;
    active!: boolean;
    description!: string;
    category!: Category;
    price!: number;
    showDescription!: boolean;
}

export class Category {
    id!: string;
    name!: string;
    active!: boolean;
}