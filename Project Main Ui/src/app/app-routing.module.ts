import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminProductsComponent } from './components/admin-products/admin-products.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutPageComponent } from './components/checkout-page/checkout-page.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ProductsByCategoryComponent } from './components/products-by-category/products-by-category.component';
import { RecieptComponent } from './components/reciept/reciept.component';
import { RegisterComponent } from './components/register/register.component';
import { ViewCartComponent } from './components/view-cart/view-cart.component';
import { ViewProductDetailsComponent } from './components/view-product-details/view-product-details.component';
import { ViewProductComponent } from './components/view-product/view-product.component';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';

const routes: Routes = [

  {path:'login',component:LoginComponent},
  {path:'signup',component:RegisterComponent},
  {path:'dashboard',component:DashboardComponent, canActivate:[RoleGuard]},
  {path:'home',component:HomeComponent},
  //{path:'products/:id', component:ViewProductComponent},
  //{path:"cart", component:CartComponent},
  {path:'products/:id', component:ViewProductDetailsComponent},
  {path:"viewCart", component:ViewCartComponent, canActivate:[AuthGuard]},
  {path:"checkout", component:CheckoutPageComponent, canActivate:[AuthGuard]},
  {path:"reciept", component:RecieptComponent, canActivate:[AuthGuard]},
  {path:'',component:HomeComponent},
  {path:'category/:id', component:ProductsByCategoryComponent},
  {path:'adminProduct', component:AdminProductsComponent,canActivate:[RoleGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
