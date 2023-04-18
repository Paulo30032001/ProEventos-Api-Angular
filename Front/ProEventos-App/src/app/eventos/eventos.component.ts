import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventos_filtrado : any = [];
  public larguraimagem: number = 150; // px
  public margem_imagem: number = 2; // px
  public ocultarimagem: boolean = false; //
  private _filtro_lista: string = null; // variavel para o filtro criada

  constructor(private http: HttpClient) {


  }

  ngOnInit(): void {
    this.GetEventos();

  }

  public get filtro_lista(){
     return this._filtro_lista;
  }

  public set  filtro_lista(filtrado : string)
  {
    this._filtro_lista =  filtrado;
    this.eventos_filtrado=  this._filtro_lista != null ? this.filtrar_lista(this.filtro_lista): this.eventos;
    // caso exista alguma coisa no filtro ele faz a consulta no arra de eventos(que permanece intacto)
    // caso não ele pega novamente todo o array de eventos
  }
  public GetEventos(): void {
    // SUBSCRIBE NÓS TEMOS QUE NOS INSCREVER
    this.http.get('https://localhost:5001/api/Eventos').subscribe(
      response => {this.eventos = response;this.eventos_filtrado = response;}, // METODO PARA ATRIBUIR O MESMO RESULTADO PARA DUAS PROPRIEDADES
      error => console.error(error),


    );

  }

  public filtrar_lista(conteudo : string): any {

     return  this.eventos.filter(
          evento=> evento.tema.toLowerCase().includes(conteudo.toLowerCase()) || evento.local.toLowerCase().includes(conteudo.toLowerCase())

     );


  }







public AlterarOcultarImagem() : void {
  this.ocultarimagem = !this.ocultarimagem;
}


}
