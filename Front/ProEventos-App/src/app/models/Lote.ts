import {Evento} from './Evento';
// necessario pois pelo o que entendi o angular não trabalha com namespaces
export interface Lote {
  id: number;

  nome: string;

  preco: number;

  dataIncio?: Date;

  dataFim?: Date;

  quantidade: number;

  eventoId: number;

  evento: Evento;


}
