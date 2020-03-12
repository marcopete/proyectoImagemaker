import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  valores: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.obtenerValores();
  }

  obtenerValores() {
    this.http.get('http://localhost:5000/api/values').subscribe(respuesta => {
      this.valores = respuesta;
    }, error => {
      console.log(error);
    });
  }

}
