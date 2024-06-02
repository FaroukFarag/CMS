import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, retry, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiURL = 'https://localhost:7096/api';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) { }

  createCustomer(customer: any): Observable<any> {
    return this.http
      .post(`${this.apiURL}/Customers/Create`, customer, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  getCustomer(id: number): Observable<any> {
    return this.http
      .get(`${this.apiURL}/Customers/Get?id=${id}`)
      .pipe(retry(1), catchError(this.handleError));
  }

  getCustomers(): Observable<any[]> {
    return this.http
      .get<any[]>(`${this.apiURL}/Customers/GetAll`)
      .pipe(retry(1), catchError(this.handleError));
  }

  updateCustomer(customer: any): Observable<any> {
    return this.http
      .put(
        `${this.apiURL}/Customers/Update`,
        customer,
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  deleteCustomer(id: any) {
    return this.http
      .delete<any>(`${this.apiURL}/Customers/Delete?id=${id}`, this.httpOptions)
      .pipe(retry(1), catchError(this.handleError));
  }

  handleError(error: any) {
    let errorMessage = '';

    if (error.error instanceof Error) {
      errorMessage = error.error.message;
    }

    else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }

    return throwError(() => {
      return errorMessage;
    });
  }
}
