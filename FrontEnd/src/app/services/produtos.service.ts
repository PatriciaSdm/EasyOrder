import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { BehaviorSubject, from, Observable, throwError } from "rxjs";
import { map, catchError, groupBy } from "rxjs/operators";
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private apiPath: string = "https://localhost:44384/api/v1/products";
  private produtos = new BehaviorSubject<Produto[]>([]);
  private auth_token: string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhMzI4MWM0My1lNjAwLTQ1YWQtOTliYi1mM2ZmYWI0NDU2NjUiLCJlbWFpbCI6ImZlbGlwZS5ndWl6em9AbGFic2l0LmlvIiwianRpIjoiMGVmNWYyMGMtNTk3Mi00YzA0LTgzNWQtMjE1OWZlYTIwODUwIiwibmJmIjoxNjM3MjQwMzQ4LCJpYXQiOjE2MzcyNDAzNDgsImV4cCI6MTYzNzI1ODM0OCwiaXNzIjoiRWFzeU9yZGVyIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3QifQ.g2vI_7cm_gyTydJU2tMVLMTmW6gKaZ4Zt18iHuIe9gI'

  constructor(private http: HttpClient) { }

  getHeaders(): HttpHeaders {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.auth_token}`
    })
    return headers;
  }

  get(): Observable<Produto[]> {
    const header = this.getHeaders();
    return this.http.get(`${this.apiPath}/with-categories`, { headers: header }).pipe(
      catchError(this.handleError),
      map(this.jsonDataToResources),
    )
  }

  // get(): Observable<Produto[]> {
  //   const header = this.getHeaders();
  //   const response = this.http.get<Produto[]>(this.apiPath, { headers: header });
  //   return response;
  // }

  getProdutos(): Observable<Produto[]> {
    return this.produtos.asObservable();
  }

  setProdutos(produtos: Produto[]): void {
    this.produtos.next(produtos);
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