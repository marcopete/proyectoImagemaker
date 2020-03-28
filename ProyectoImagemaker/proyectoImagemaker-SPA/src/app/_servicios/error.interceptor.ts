import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class InterceptorErrores implements HttpInterceptor {
  intercept(
    req: import('@angular/common/http').HttpRequest<any>,
    next: import('@angular/common/http').HttpHandler
  ): import('rxjs').Observable<import('@angular/common/http').HttpEvent<any>> {
    return next.handle(req).pipe(
        catchError(error => {
            if (error.status === 401) {
                return throwError(error.statusText);
            }
            if (error instanceof HttpErrorResponse) {
                const errorAplicacion = error.headers.get('Application-Error'); // Desde Extensiones.cs

                if (errorAplicacion) {
                    return throwError(errorAplicacion);
                }
                const errorServidor = error.error;
                let erroresStandard = '';
                if (errorServidor.errors && typeof errorServidor.errors === 'object') {
                  for (const llave in errorServidor.errors) {
                      if (errorServidor.errors[llave]) {
                          erroresStandard += errorServidor.errors[llave] + '\n';
                      }
                  }
                }
                return throwError(erroresStandard || errorServidor || 'Error de servidor');
            }
        })
    );
  }
}

export const ProveedorDeInterceptorDeErrores = {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorErrores,
    multi: true
};
