import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomerService } from '../../../services/customers/customer.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-customer',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent implements OnInit {
  id = 0;
  customerForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private customerService: CustomerService,
    private router: Router) { }

  ngOnInit(): void {
    this.createForm();

    this.id = +this.route.snapshot.paramMap.get('id')!;

    if (this.id) {
      this.initializeCustomer(this.id);
    }
  }

  createForm() {
    this.customerForm = this.formBuilder.group({
      id: [0],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required]
    });
  }

  initializeCustomer(id: any) {
    this.customerService.getCustomer(id).subscribe(data => {
      this.initializeForm(data);
    });
  }

  initializeForm(customer: any) {
    this.customerForm.patchValue({
      id: customer.id,
      firstName: customer.firstName,
      lastName: customer.lastName,
      email: customer.email,
      phone: customer.phone,
      address: customer.address
    });
  }

  onSubmit() {
    if (this.id) {
      this.customerService.updateCustomer(this.customerForm.value).subscribe();
    } else {
      this.customerService.createCustomer(this.customerForm.value).subscribe();
    }

    this.router.navigate(['/customers']);
  }
}
