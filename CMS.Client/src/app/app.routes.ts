import { Routes } from '@angular/router';
import { CustomersComponent } from './components/customers/customers.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { EditCustomerComponent } from './components/customers/edit-customer/edit-customer.component';
import { LoginComponent } from './components/users/login/login.component';
import { RegisterComponent } from './components/users/register/register.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: 'customers',
    canActivate: [authGuard],
    children: [
      { path: '', component: CustomersComponent },
      { path: 'create', component: EditCustomerComponent },
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
