import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customers/customer.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent  implements OnInit {
  customers!: any[];

  constructor(private customerService: CustomerService, private router: Router) { }

  ngOnInit(): void {
    this.initializeCustomers();
  }

  initializeCustomers() {
    this.customerService.getCustomers().subscribe(data => {
      this.customers = data;
    })
  }

  public trackItem (index: number, customer: any) {
    return customer.id;
  }

  onDelete(id: number) {
    if(confirm("Are you sure to delete this category?")) {
      this.customerService.deleteCustomer(id).subscribe(() => {
        this.customers = this.customers.filter(customer => customer.id !== id);
      });
    }
  }
}
