import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
 public eventos : any ;
  constructor(private http : HttpClient) {
   }

  ngOnInit(): void {
    this.GetEventos();
  }

  public GetEventos() : void {
     // SUBSCRIBE NÓS TEMOS QUE NOS INSCREVER
    this.http.get('https://localhost:5001/api/Eventos').subscribe(
           response=>this.eventos=response ,
           error=>console.error(error)

    );

}


}
