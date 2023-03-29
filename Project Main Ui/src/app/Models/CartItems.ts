interface Product {
    productId: number;
    name: string;
    description: string;
    categoryId: number;
    price: number;
    imageName: string;
    category: any;
  }
  
  interface CartItem {
    cartItemId: number;
    cartId: number;
    productId: number;
    carts: any;
    products: Product;
    quantity: number;
  }
  
export interface Carts {
    cartId: number;
    userId: number;
    totalPrice: number;
    users: any;
    cartItems: CartItem[];
  }
  