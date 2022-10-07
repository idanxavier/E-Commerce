import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";
import { ProductDTO } from "src/app/model/DTOs/productDTO";
import { Product } from "src/app/model/Product";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    categories = ["Moda", "Higíene", "Gastronomia", "Esporte"];

    constructor(private http: HttpClient) { }

    ListAllProducts() {
        return this.http.get(`${environment.apiUrl}/Product/list-all-products`)
    }

    CreateProduct(product: ProductDTO) {
        return this.http.post<Product>(`${environment.apiUrl}/Product/new-product`, product)
            .pipe(map((data: any) => {
                return data;
            }))
    }
}