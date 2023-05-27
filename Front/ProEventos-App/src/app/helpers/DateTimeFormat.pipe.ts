import { DatePipe } from "@angular/common";  // USADO PARA EXTENDENDER O DATETPIPE
import { Pipe, PipeTransform } from "@angular/core";
import {Cultura} from "../util/Cultura";
@Pipe({
  name: "DateTimeFormat"
})
  //ESTAMOS IMPLEMENTANDO(CUMPRINDO O CONTRATO ) A INTERFACE PIPETRANSFORM
 //EXTENDS ESTAMOS HERDANDO SOBRESCREVENDO A CLASSE DATEPIPE
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
 // SUPER É ESQUIVALENTE AO BASE NO C# ESTÁ USANDO O PROPRIO METODO QUE
  // ENTÃO AQUI ELE ESTÁ HERANDO DE DATEPIPE( OU SEJA O PIPE(FILTRO) DE DATA)
  //E ESTÁ IMPLEMENTANDO(CUMPRINDO O CONTRATO) DA INTERFACE PIPETRANFORM
  //E IMPLEMENTANDO  O METODO DA INTERFACE
  //E USANDO A REFERENCIA DE SUPER(BASE EM C#) PARA A CLASSE QUE ESTÁ HERDANDO (DATEPIPE)
  // QUE TAMBEM IMPLEMENTA A INTERFACE

      return   super.transform(value,Cultura.BrDatHora);
  }

}
