import { Component, OnInit } from "@angular/core"; // FORMA VARIOS OBJETOS QUE VEM DO MESMO LOCAL

@Component({
  selector: "app-eventos",
  templateUrl: "./eventos.component.html",
  styleUrls: ["./eventos.component.scss"],
  /* providers: [EventoService]  2 MANEIRA DE SE USAR A INJEÇÃO DE DEPENDENCIA
    DECLARANDO NA PROPRIA CLASE */
})
export class EventosComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
