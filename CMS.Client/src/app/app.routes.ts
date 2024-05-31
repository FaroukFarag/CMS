import { Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CreateCustomerComponent } from './customers/create-customer/create-customer.component';
import { EditCustomerComponent } from './customers/edit-customer/edit-customer.component';

export const routes: Routes = [
    { 
        path: 'customers',
        children: [
          { path: '', component: CustomersComponent },
          { path: 'create', component: CreateCustomerComponent },
          { path: 'edit/:id', component: EditCustomerComponent }
        ]
       },
      { path: '',   redirectTo: '/customers', pathMatch: 'full' },
      { path: '**', component: NotFoundComponent }
];
