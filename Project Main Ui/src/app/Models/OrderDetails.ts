export interface Order {
    id: string;
    userId: number;
    name: string;
    email: string;
    address:string;
    total:number;
    products: Product[];
  }
  
  export interface Product {
    name: string;
    price: number;
    quantity: number;
  }
  