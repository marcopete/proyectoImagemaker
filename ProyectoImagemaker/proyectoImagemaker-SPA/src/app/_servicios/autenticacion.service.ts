import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {
  urlBase = 'http://localhost:5000/api/autorizacion/';
  apoyoJwt = new JwtHelperService();
  tokenDecodificado: any;

  constructor(private http: HttpClient) { }

  login(modelo: any) {
    return this.http.post(this.urlBase + 'login', modelo)
      .pipe(
        map((respuesta: any) => {
          const usuario = respuesta;
          if (usuario) {
            localStorage.setItem('token', usuario.token);
            this.tokenDecodificado = this.apoyoJwt.decodeToken(usuario.token);
            console.log(this.tokenDecodificado);
          }
        })
      );
  }

  registrar(modelo: any) {
    return this.http.post(this.urlBase + 'registrar', modelo);
  }

  logueado() {
    const token = localStorage.getItem('token');
    return !this.apoyoJwt.isTokenExpired(token);
  }

}
