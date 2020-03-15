import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {
  urlBase = 'http://localhost:5000/api/autorizacion/';

constructor(private http: HttpClient) { }

login(modelo: any) {
  return this.http.post(this.urlBase + 'login', modelo)
    .pipe(
      map((respuesta: any) => {
        const usuario = respuesta;
        if (usuario) {
          localStorage.setItem('token', usuario.token);
        }
      })
    );
}

}
