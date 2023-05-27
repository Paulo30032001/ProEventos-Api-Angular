import { Component, OnInit, TemplateRef } from "@angular/core"; // FORMA VARIOS OBJETOS QUE VEM DO MESMO LOCAL
import { EventoService } from "../../services/Evento.service"; // IMPORTANTO EVENTOSERVICE
import { Evento } from "../../models/Evento"; // IMPORTANDO A CLASSE DE ENVENTO PARA TIPAR AS VARIAVEIS E METODOS
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal"; // IMPORTADO PARA CONSEGUIR DISPARAR O MODAL(JANELA)
import { ToastrService } from "ngx-toastr";// IMPORTADO PARA CONSEGUIR EXIBIR OS ALERTAS FORMATADOS (COMO NOTIFICAÇÕES)
import { NgxSpinnerService } from "ngx-spinner";  //E A DIRETIVA (RECURSO DO ANGULAR PARA MANIPULAR O HTML) DE NGX-SPINNER
@Component({
  selector: "app-eventos",
  templateUrl: "./eventos.component.html",
  styleUrls: ["./eventos.component.scss"],
  /* providers: [EventoService]  2 MANEIRA DE SE USAR A INJEÇÃO DE DEPENDENCIA
    DECLARANDO NA PROPRIA CLASE */
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public eventosFiltrado: Evento[] = [];
  public larguraImagem = 150; // px
  public margemImagem = 2; // px
  public ocultarImagem = false; //
  private filtroLista: string = null; // variavel para o filtro criada
  private modalRef?: BsModalRef;



  // CRIADO PARA CONSEGUIR DISPARAR O MODAL(JANELA)
  // COMO FOI DECLARADO COMO MODULO O MODALMODULE
  // E EXECUTOU O METODO FORROOT()
  // ACREDITO QUE ISSO POSSIBILITE
  // IGUAL AOS MODULOS OU COMPONENTES USAR AQUILO EM TODO O PROJETO
  // ESSES MODULOS QUE USAMOS ATÉ AGORA(COLLAPSE,TOOLTIP,DROPDOWN,MODAL)
  //PARA SEREM USADOS NAS VIEWS OU EM OUTRAS CLASSES PARA INJEÇÃO DE DEPENDENCIA TODOS PRECISARAM DO METODO FOR ROOT

  // PARA USAR QUALQUER COISA QUE VENHA COM INJEÇÃO DE DEPENDENCIA É NECESSARIO USAR OS MODIFICADORES
  //ACESSO
  //TODAS CLASSES PASSADAS AQUI  USAM O DECORATOR(METADADOS DE CONFIGURAÇÃO DA CLASSE) INJECTABLE
  //FAZEM A INJEÇÃO DE DEPENDENCIA QUANDO OS QUE EXECUTAM O METODO FORROOT() AI ELES FAZEM A INJEÇÃO DE DEPENDENCIA USANDO O DECORATOR INJECTABLE
  constructor(private service: EventoService, private modalService: BsModalService,
            private toastrService: ToastrService,private ngxSpinnerService : NgxSpinnerService) {}

  ngOnInit(): void {
    //this.ngxSpinnerService.show();
    // SET TIMEOUT RECEBE UMA FUNÇÃO DE CALLBACK(FUNÇÃO QUE VAI SER EXECUTADA APÓS O FIM DA FUNÇÃO QUE A RECEBEU COMO PARAMETRO OU QUANDO ELA FOR CHAMADA DENTRO DO BLOBO DA FUNÇÃO)
     //QUE VAI SER EXECUTADA APÓS 5 SEGUNDOS

    this.ngxSpinnerService.show(
      "carregando", {
        type: "ball-clip-rotate", //square-jelly-box
        size: "large",
        bdColor: "rgba(0, 0, 0, 1)",
        color: "white",
        template: "<img src='https://media.giphy.com/media/o8igknyuKs6aY/giphy.gif' / >"
      }
    );
    this.GetEventos();

  }
  // COMO NA VERDADE ISSO VAI VIR A SER UMA VARIAVEL APESSAR DE NÃO ESTAR DECLARADA ENTÃO NÃO PODE TER O NOME
  // IGUAL AO DE OUTRA VARIAVEL
  public get filtroDeLista(): string {
    return this.filtroLista;
  }

  public set filtroDeLista(filtrado: string) {
    this.filtroLista = filtrado;
    this.eventosFiltrado = this.filtroLista != null ? this.filtrar_lista(this.filtroLista) : this.eventos;
    // caso exista alguma coisa no filtro ele faz a consulta no arra de eventos(que permanece intacto)
    // caso não ele pega novamente todo o array de eventos
  }
  public GetEventos(): void {
    // SUBSCRIBE NÓS TEMOS QUE NOS INSCREVER
    //GET EVENTO RETORNA UM OBSERVABLE QUE VEM DO METODO GET DO HTTPCLIENT
    //OBSERVER (UM OBJETO QUALQUER NÃO EXISTE UMA CLASSE OU TIPO OBSERVER)

    const Observer = {
      // funções anonimas () =>{}
      next: (Eventos: Evento[]) => { // representa o corpo do response
        this.eventos = Eventos; this.eventosFiltrado = Eventos;
        this.toastrService.success("Eventos carregados", "Sucesso");
        this.ngxSpinnerService.hide("carregando");
      },
      error: (Error: object) => {
        console.error(Error);
        this.toastrService.error("Ops ocorreu um erro na requisição", "Erro");
        this.ngxSpinnerService.hide("carregando");
      },
      // CAPTURA O RETORNO DA REQUISIÇÃO
      complete : () => {
              this.ngxSpinnerService.hide("carregando");
      }


      // o complete ainda não vamos fazer (status da requisição(response da resposta))
    };

    this.service.GetEventos().subscribe(Observer);



  }

  public filtrar_lista(conteudo: string) {

    return this.eventos.filter(
      evento => evento.tema.toLowerCase().includes(conteudo.toLowerCase()) || evento.local.toLowerCase().includes(conteudo.toLowerCase())

    );


  }


  public AlterarOcultarImagem(): void {
    this.ocultarImagem = !this.ocultarImagem;
  }



  public OpenModal(template: TemplateRef<string>): void {
    //UMA STRING UM NOME E BUSCA NA VIEW PELA DIRETIVA QUE CONTEM ESSE ID
    // PASSA A REFERENCIA(EM MEMORIA) PARA A NOSSA VARIAVEL APARTIR DAI AS DUAS APONTAM PARA O MESMO LOCAL
    // E ENTÃO PODEMOS ABRIR E FECHAR O MODALREF
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });

  }

  public Confirm(): void {
    this.modalRef.hide(); // FECHANDO  texto          titulo
    this.toastrService.success("Excluido", "Sucesso");
  }


  public Cancel(): void // dei o nome como eu achei melhor
  {
    this.modalRef.hide(); // FECHANDO
    this.toastrService.warning("Cancelado", "Ok");
  }

}
