import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { BehaviorSubject, Observable, throwError } from "rxjs";
import { map, catchError } from "rxjs/operators";
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private apiPath: string = "http://localhost:3000/produtos";
  public produtos$ = new BehaviorSubject<Produto[]>([]);

  constructor(private http: HttpClient) { }

  get(): Observable<Produto[]> {
    return this.http.get(this.apiPath).pipe(
      catchError(this.handleError),
      map(this.jsonDataToResources),
    )
  }

  getById(id: string): Observable<Produto> {
    const url = `${this.apiPath}/${id}`;

    return this.http.get(url).pipe(
      catchError(this.handleError),
      map(this.jsonDataToResource)
    )
  }

  insert(produto: Produto): Observable<Produto> {
    return this.http.post(this.apiPath, produto).pipe(
      catchError(this.handleError),
      map(this.jsonDataToResource)
    )
  }

  update(produto: Produto): Observable<Produto> {
    const url = `${this.apiPath}/${produto.id}`;

    return this.http.put(url, produto).pipe(
      catchError(this.handleError),
      map(() => produto)
    )
  }

  delete(produtoId: number): Observable<any> {
    const url = `${this.apiPath}/${produtoId}`;

    return this.http.delete(url).pipe(
      catchError(this.handleError),
      map(() => null)
    )
  }

  // Métodos privados
  private jsonDataToResources(jsonData: any[]): Produto[] {
    const resources: Produto[] = [];
    jsonData.forEach(element => resources.push(element as Produto));
    return resources;
  }

  private jsonDataToResource(jsonData: any): Produto {
    return jsonData as Produto;
  }

  private handleError(error: any): Observable<any> {
    console.log("ERRO NA REQUISIÇÃO => ", error);
    return throwError(error);
  }
}