import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http"; // NECESSARIO PARA O USO DO HTTCLIENT
import { Observable } from "rxjs"; // BIBLIOTECA DO OBSERVABLE (RETORNO DO GET DO HTTP)
import {Evento} from "../models/Evento"; // IMPORTADO PARA PODER USAR OS EVENTOS
@Injectable(/* {providedIn: 'root'}*/)

export class EventoService {
private  Url = "https://localhost:5001/api/Eventos";
   /*
AQUI ELE FAZ A INJEÇÃO DE DEPENDENCIA POIS AQUI O HTTPCLIENT USA O DECORATOR
Injectable(OU SEJA É UMA CLASSE INJETAVEL) PARA PODER SER USADO COMO UM SERVIÇO
EM TODA A APLICAÇÃO
*/
// PARA USAR QUALQUER COISA QUE VENHA COM INJEÇÃO DE DEPENDENCIA É NECESSARIO USAR OS MODIFICADORES
//ACESSO
constructor(private http : HttpClient) { }

//UMA CLASSE GENERICA(OBSERVABLE) QUANDO DECLARADA(NESSE CASO O TIPO QUE VAMOS RETORNAR) PEDE UM TIPO
public  GetEventos()  : Observable<Evento[]> { // Aqui retorna um array de eventos
  // SUBSCRIBE NÓS TEMOS QUE NOS INSCREVER
   return this.http.get<Evento[]>(this.Url);

}

public GetEventosByTema(tema :string) : Observable<Evento[]>
{
   return this.http.get<Evento[]>(`${this.Url}/tema/${tema}`);
}

public GetEventosById(id : number) : Observable<Evento>
{
   return this.http.get<Evento>(`${this.Url}/${id}`);
}

}
