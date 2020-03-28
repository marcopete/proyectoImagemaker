import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

 confirma(mensaje: string, retornoOk: () => any) {
   alertify.confirm(mensaje, (e: any) => {
     if (e) {
       retornoOk();
     } else {}
   });
 }

 exito(mensaje: string) {
   alertify.success(mensaje);
 }

 error(mensaje: string) {
  alertify.error(mensaje);
}

warning(mensaje: string) {
  alertify.warning(mensaje);
}

mensaje(mensaje: string) {
  alertify.message(mensaje);
}

}
