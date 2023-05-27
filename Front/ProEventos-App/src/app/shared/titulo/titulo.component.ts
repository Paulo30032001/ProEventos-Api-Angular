import { Component, Input,OnInit } from "@angular/core"; // O DECORATOR(METADADOS DE CONFIGUGURAÇÃO DA CLASSE)
// DE INPUT PRECISA SER IMPORTADO DO CORE DO ANGULAR
// REPARE QUE COMPONENT E OnInit(VAI SER CARREGADO ANTES DA NOSSA APLICAÇÃO) TAMBÉM SÃO TRAZIDOS
// DO CORE DO ANGULAR

@Component({
  selector: "app-titulo",
  templateUrl: "./titulo.component.html",
  styleUrls: ["./titulo.component.scss"]
})
export class TituloComponent implements OnInit {
   @Input() titulo :string; // PARA O DECORATOR DE ENTRADA NÃO SE DEVE USAR MODIFICADORES DE ACESSO
   // POIS COMO É DE ENTRADA DEVE SER SEMPRE PUBLICO
  constructor() { }

  ngOnInit(): void {
  }

}
