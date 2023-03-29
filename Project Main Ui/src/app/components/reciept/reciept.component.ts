import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from 'src/app/Models/OrderDetails';

@Component({
  selector: 'app-reciept',
  templateUrl: './reciept.component.html',
  styleUrls: ['./reciept.component.css']
})
export class RecieptComponent {

  orderDetails: Order = {
    id: '',
    userId: 456,
    name: 'John Doe',
    email: 'john.doe@example.com',
    address:"address",
    total:121,
    products: []
  };

  id:any;

  
  constructor(private route: ActivatedRoute){}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.orderDetails = JSON.parse(params['order1']);
      
      
      
    });
    

    console.log("in reciept component:"+this.orderDetails.id)
  }



}
