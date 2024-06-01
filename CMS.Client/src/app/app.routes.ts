import { Routes } from '@angular/router';
import { CustomersComponent } from './components/customers/customers.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { CreateCustomerComponent } from './components/customers/create-customer/create-customer.component';
import { EditCustomerComponent } from './components/customers/edit-customer/edit-customer.component';
import { LoginComponent } from './components/users/login/login.component';
import { RegisterComponent } from './components/users/register/register.component';

export const routes: Routes = [
  {
    path: 'customers',
    children: [
      { path: '', component: CustomersComponent },
      { path: 'create', component: CreateCustomerComponent },
      { path: 'edit/:id', component: EditCustomerComponent }
    ]
  },
  {
    path: 'users',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent }
    ]
  },
  { path: '', redirectTo: '/customers', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];
