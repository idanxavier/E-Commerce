import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    constructor(private http: HttpClient) { }

    ListAllProducts() {
        return this.http.get(`${environment.apiUrl}/Product/list-all-products`)
    }
}