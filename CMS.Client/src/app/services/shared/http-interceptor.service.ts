import { HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../users/auth.service';

export function httpInterceptorService(req: HttpRequest<unknown>, next: HttpHandlerFn) {
  const token = inject(AuthService).getToken();

  const newReq = req.clone({
    headers:
      req.headers.append('Authorization', `Bearer ${token}`),
  });

  return next(newReq);
}
