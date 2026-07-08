import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');
  const publicUrls = [
  '/api/Auth/Login',
  '/api/Auth/Register'
];

const isPublicApi = publicUrls.some(url =>
  req.url.includes(url)
);

if (isPublicApi) {
  return next(req);
}
  if(!token){
    return next(req);
  }
     const clonedRequest = req.clone({
      setHeaders:{
        Authorization: `Bearer ${token}`
      }
     });
    return next(clonedRequest);
};
