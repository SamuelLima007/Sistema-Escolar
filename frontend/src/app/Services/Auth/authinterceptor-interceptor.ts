import { HttpInterceptorFn } from '@angular/common/http';
import { inject, Inject, Injector } from '@angular/core';
import { Authservice } from './authservice';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const _authservice = inject(Authservice);
  const token = _authservice.GetToken();

  if (token) {
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` },
    });
  }

  return next(req);
};
