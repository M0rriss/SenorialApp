import { HttpInterceptorFn } from '@angular/common/http';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  var token:string = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsImlhdCI6MTcyMzA4NTA4NSwianRpIjoiOC84LzIwMjQgMDI6NDQ6NDUiLCJuYmYiOjE3MjMwODUwODUsImV4cCI6MTcyMzA5MDQ4NX0.q6GElPv4AUVqEkmGfHedbAO-nHRn7AmprP14g6-quSI';

  const modreq = req.clone({
    setHeaders: {
      authorization: `Bearer ${token}`
    }
  });

  return next(modreq);
};
