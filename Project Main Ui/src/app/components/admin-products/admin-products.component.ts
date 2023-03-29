import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent {


  productList:any


  public dataSource!: MatTableDataSource<any>;
  displayedColumns: string[]=["name","description","price","Operations"]

  myProduct: any = 
  {
    productId: 1,
    name: 'Product Name',
    description: 'Product description',
    categoryId: 2,
    price: 19.99,
    imageName: 'product.jpg',
    category:""
   
};


tempProduct: any = 
{
  productId: 1,
  name: 'Product Name',
  description: 'Product description',
  categoryId: 2,
  price: 1999,
  imageName: 'product.jpg',
  category:""
 
};

  category:any
 

  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!:MatSort;
  constructor(private product:ProductServiceService){
    
  }

  ngOnInit(){
    this.getAllProducts()
   
  }


  getAllProducts(){
    this.product.getAllProducts().subscribe((resp)=>{
      this.productList = resp
      console.log(this.productList)
      this.dataSource = new MatTableDataSource(this.productList)
        this.dataSource.paginator = this.paginator
        this.dataSource.sort = this.sort

    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }


}




addProduct(){
  this.myProduct.categoryId = +this.myProduct.categoryId
  console.log(this.myProduct)
  this.product.addProduct(this.myProduct).subscribe((resp)=>{
    console.log(resp)
  })

}






deleteProduct(product:any){

  console.log(product)
  this.product.deleteProduct(product.productId).subscribe((resp)=>{
    console.log(resp)
    this.getAllProducts()
  })
  
}

getProduct(product:any){
  this.tempProduct = product
  console.log(this.tempProduct)


}



updateProduct(){
  this.myProduct.productId = this.tempProduct.productId
  console.log(this.myProduct)
  this.product.updateProduct(this.myProduct).subscribe((resp)=>{
    console.log(resp)
    this.getAllProducts()
  })



}




}