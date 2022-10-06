import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/productService';
import { Product } from 'src/app/model/Product';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  products: Product[] = []

  constructor(private productService: ProductService) {
    this.productService.ListAllProducts().subscribe((data: any) => {
      this.products = data;
    })
  }

  ngOnInit(): void {
  }

}
