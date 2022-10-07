import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ProductService } from 'src/app/core/services/productService';
import { ProductDTO } from 'src/app/model/DTOs/productDTO';
import { Product } from 'src/app/model/Product';

class ImageSnippet {
  constructor(public src: string, public file: File) { }
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  products: Product[] = []
  productName: string = ""
  productPrice: number = 0
  productInventory: number = 0
  productPhoto: string = ""
  productCategory: string = ""
  categories: string[] = []
  selectedFile?: ImageSnippet;

  constructor(private productService: ProductService, public domSanitizer: DomSanitizer) {
    this.productService.ListAllProducts().subscribe((data: any) => {
      this.products = data;
    })
    this.categories = this.productService.categories;
  }

  NewProduct() {
    var name = this.productName.charAt(0).toUpperCase() + this.productName.slice(1);
    var productDTO = new ProductDTO(name, this.productPrice, this.productPhoto, this.productInventory, this.productCategory);
    this.productService.CreateProduct(productDTO).subscribe(data => {
      this.ListProducts();
    })
  }

  ListProducts() {
    this.productService.ListAllProducts().subscribe((data: any) => {
      this.products = data;
    })
  }

  processFile(imageInput: any) {
    const file: File = imageInput.files[0];
    const reader = new FileReader();

    reader.addEventListener('load', (event: any) => {

      this.selectedFile = new ImageSnippet(event.target.result, file);
      this.productPhoto = this.selectedFile.src;
    });

    reader.readAsDataURL(file);
  }

  getSafeUrl(url: string) {
    return this.domSanitizer.bypassSecurityTrustResourceUrl(`${atob(url)}`);
  }

  ngOnInit(): void {
  }

}
